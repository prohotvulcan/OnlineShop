﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Product;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace olShop.Application.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory, int> _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IRepository<ProductCategory, int> productCategoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            _productCategoryRepository.Add(_mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm));
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository
                .FindAll()
                .OrderBy(x => x.ParentId)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository
                    .FindAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                    .OrderBy(x => x.ParentId)
                    .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                return _productCategoryRepository
                    .FindAll()
                    .OrderBy(x => x.ParentId)
                    .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                    .ToList();
            }
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository
                .FindAll(x => x.ParentId == parentId && x.Status == Status.Active)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return _mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository
                .FindAll(x => x.HomeFlag == true, c => c.Products)
                .OrderBy(x => x.HomeOrder)
                .Take(top)
                .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider);

            var categories = query.ToList();

            //foreach (var category in categories)
            //{
            //    category.Products = _productCategoryRepository
            //        .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
            //        .OrderByDescending(x => x.DateCreated)
            //        .Take(5)
            //        .ProjectTo<ProductViewModel>().ToList();
            //}
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _productCategoryRepository.FindById(sourceId);
            var target = _productCategoryRepository.FindById(targetId);

            source.SortOrder = source.SortOrder + target.SortOrder;
            target.SortOrder = source.SortOrder - target.SortOrder;
            source.SortOrder = source.SortOrder - target.SortOrder;

            _productCategoryRepository.Update(source);
            _productCategoryRepository.Update(target);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            _productCategoryRepository.Update(_mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm));
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var source = _productCategoryRepository.FindById(sourceId);
            source.ParentId = targetId;
            _productCategoryRepository.Update(source);

            var sibling = _productCategoryRepository.FindAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _productCategoryRepository.Update(child);
            }
        }
    }
}
