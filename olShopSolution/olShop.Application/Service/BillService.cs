using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Product;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace olShop.Application.Service
{
    public class BillService : IBillService
    {
        private readonly IRepository<Bill, int> _billRepository;
        private readonly IRepository<BillDetail, int> _billDetailRepository;
        private readonly IRepository<Color, int> _colorRepository;
        private readonly IRepository<Size, int> _sizeRepository;
        private readonly IRepository<Product, int> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillService(IRepository<Bill, int> billRepository,
            IRepository<BillDetail, int> billDetailRepository,
            IRepository<Color, int> colorRepository,
            IRepository<Size, int> sizeRepository,
            IRepository<Product, int> productRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._billRepository = billRepository;
            this._billDetailRepository = billDetailRepository;
            this._colorRepository = colorRepository;
            this._sizeRepository = sizeRepository;
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Create(BillViewModel billVm)
        {
            var bill = _mapper.Map<BillViewModel, Bill>(billVm);
            var billDetails = _mapper.Map<List<BillDetailViewModel>, List<BillDetail>>(billVm.BillDetails);

            foreach (var detail in billDetails)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
            }
            bill.BillDetails = billDetails;

            _billRepository.Add(bill);
        }

        public BillDetailViewModel CreateDetail(BillDetailViewModel billDetailVm)
        {
            var billDetail = _mapper.Map<BillDetailViewModel, BillDetail>(billDetailVm);
            _billDetailRepository.Add(billDetail);
            return billDetailVm;
        }

        public void DeleteDetail(int productId, int billId, int colorId, int sizeId)
        {
            var billDetail = _billDetailRepository
                .FindSingle(x => x.ProductId == productId 
                && x.BillId == billId 
                && x.ColorId == colorId 
                && x.SizeId == sizeId);

            _billDetailRepository.Remove(billDetail);
        }

        public PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize)
        {
            var bill = _billRepository.FindAll();

            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                bill = bill.Where(x => x.DateCreated >= start);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                bill = bill.Where(x => x.DateCreated <= end);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                bill = bill.Where(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            }
            var totalRow = bill.Count();
            var data = bill.OrderByDescending(x => x.DateCreated)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BillViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return new PagedResult<BillViewModel>()
            {
                CurrentPage = pageIndex,
                PageSize = pageSize,
                Results = data,
                RowCount = totalRow
            };
        }

        public List<BillDetailViewModel> GetBillDetails(int billId)
        {
            return _billDetailRepository
                .FindAll(x => x.BillId == billId, x => x.Bill, x => x.Color, x => x.Size, x => x.Product)
                .ProjectTo<BillDetailViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public ColorViewModel GetColor(int id)
        {
            return _mapper.Map<Color, ColorViewModel>(_colorRepository.FindById(id));
        }

        public List<ColorViewModel> GetColors()
        {
            return _colorRepository.FindAll()
                .ProjectTo<ColorViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public BillViewModel GetDetail(int billId)
        {
            var bill = _billRepository.FindSingle(x => x.Id == billId);
            var billVm = _mapper.Map<Bill, BillViewModel>(bill);
            var billDetailVm = _billDetailRepository
                .FindAll(x => x.BillId == billId)
                .ProjectTo<BillDetailViewModel>(_mapper.ConfigurationProvider)
                .ToList();
            billVm.BillDetails = billDetailVm;
            return billVm;
        }

        public SizeViewModel GetSize(int id)
        {
            return _mapper.Map<Size, SizeViewModel>(_sizeRepository.FindById(id));
        }

        public List<SizeViewModel> GetSizes()
        {
            return _sizeRepository.FindAll()
                .ProjectTo<SizeViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(BillViewModel billVm)
        {
            // mapping to view model
            var bill = _mapper.Map<BillViewModel, Bill>(billVm);
            
            // get bill detail
            var newBillDetails = bill.BillDetails;

            // get new details added
            var addedBillDetails = newBillDetails.Where(x => x.Id == 0);

            // get new details update
            var updateBillDetails = newBillDetails.Where(x => x.Id != 0);

            // get existed details
            var existedDetails = _billDetailRepository.FindAll(x => x.BillId == billVm.Id);

            // clear all details
            bill.BillDetails.Clear();

            // update details
            foreach (var detail in updateBillDetails)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
                _billDetailRepository.Update(detail);
            }

            // add new details
            foreach (var detail in addedBillDetails)
            {
                var product = _productRepository.FindById(detail.ProductId);
                detail.Price = product.Price;
                _billDetailRepository.Add(detail);
            }

            // remove existed details
            _billDetailRepository.RemoveMultiple(existedDetails.Except(updateBillDetails).ToList());

            // update bill
            _billRepository.Update(bill);
        }

        public void UpdateStatus(int billId, BillStatus billStatus)
        {
            var bill = _billRepository.FindById(billId);
            bill.BillStatus = billStatus;
            _billRepository.Update(bill);
        }
    }
}
