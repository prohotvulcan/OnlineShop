using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Blog;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace olShop.Application.Service
{
    public class PageService : IPageService
    {
        private readonly IRepository<Page, int> _pageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PageService(IRepository<Page, int> pageRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._pageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Add(PageViewModel pageVm)
        {
            _pageRepository.Add(_mapper.Map<PageViewModel, Page>(pageVm));
        }

        public void Delete(int id)
        {
            _pageRepository.Remove(id);
        }

        public List<PageViewModel> GetAll()
        {
            return _pageRepository
                .FindAll()
                .ProjectTo<PageViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _pageRepository.FindAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = query.Count();
            var data = query
                .OrderByDescending(x => x.Alias)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<PageViewModel>
            {
                Results = data.ProjectTo<PageViewModel>(_mapper.ConfigurationProvider).ToList(),
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public PageViewModel GetByAlias(string alias)
        {
            return _mapper.Map<Page, PageViewModel>(_pageRepository.FindSingle(x => x.Alias == alias));
        }

        public PageViewModel GetById(int id)
        {
            return _mapper.Map<Page, PageViewModel>(_pageRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PageViewModel pageVm)
        {
            _pageRepository.Update(_mapper.Map<PageViewModel, Page>(pageVm));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
