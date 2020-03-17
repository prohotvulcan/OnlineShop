using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.System;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olShop.Application.Service
{
    public class FunctionService : IFunctionService
    {
        private readonly IRepository<Function, string> _functionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FunctionService(IRepository<Function, string> functionRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._functionRepository = functionRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        
        public void Add(FunctionViewModel functionVm)
        {
            _functionRepository.Add(_mapper.Map<FunctionViewModel, Function>(functionVm));
        }

        public bool CheckExistedId(string id)
        {
            return _functionRepository.FindById(id) != null;
        }

        public void Delete(string id)
        {
            _functionRepository.Remove(id);
        }

        public Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var query = _functionRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Name.Contains(filter));
            }
            return query
                .OrderBy(x => x.ParentId)
                .ProjectTo<FunctionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId)
        {
            return _functionRepository
                .FindAll(x => x.ParentId == parentId)
                .ProjectTo<FunctionViewModel>(_mapper.ConfigurationProvider);
        }

        public FunctionViewModel GetById(string id)
        {
            return _mapper.Map<Function, FunctionViewModel>(_functionRepository.FindById(id));
        }

        public void ReOrder(string sourceId, string targetId)
        {
            var source = _functionRepository.FindById(sourceId);
            var target = _functionRepository.FindById(targetId);

            //int tempOrder = source.SortOrder;
            //source.SortOrder = target.SortOrder;
            //target.SortOrder = tempOrder;
            // a = 5, b = 4
            source.SortOrder = source.SortOrder + target.SortOrder; // a = 9
            target.SortOrder = source.SortOrder - target.SortOrder; // b = 5
            source.SortOrder = source.SortOrder - target.SortOrder; // a = 4

            _functionRepository.Update(source);
            _functionRepository.Update(target);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FunctionViewModel functionVm)
        {
            _functionRepository.Update(_mapper.Map<FunctionViewModel, Function>(functionVm));
        }

        public void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            // update parent id
            var category = _functionRepository.FindById(sourceId);
            category.ParentId = targetId;
            _functionRepository.Update(category);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
