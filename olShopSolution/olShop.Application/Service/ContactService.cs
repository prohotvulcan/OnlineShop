using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Common;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace olShop.Application.Service
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact, string> _contactRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ContactService(IRepository<Contact, string> contactRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Add(ContactViewModel contactVm)
        {
            var contact = _mapper.Map<ContactViewModel, Contact>(contactVm);
            _contactRepository.Add(contact);
        }

        public void Delete(string id)
        {
            _contactRepository.Remove(id);
        }

        public List<ContactViewModel> GetAll()
        {
            return _contactRepository
                .FindAll()
                .ProjectTo<ContactViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _contactRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            int totalRow = query.Count();

            var data = query
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<ContactViewModel>
            {
                Results = data.ProjectTo<ContactViewModel>(_mapper.ConfigurationProvider).ToList(),
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public ContactViewModel GetById(string id)
        {
            return _mapper.Map<Contact, ContactViewModel>(_contactRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ContactViewModel contactVm)
        {
            _contactRepository.Update(_mapper.Map<ContactViewModel, Contact>(contactVm));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
