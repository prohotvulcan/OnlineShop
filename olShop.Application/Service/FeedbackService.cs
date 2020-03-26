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
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback, int> _feedbackRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackService(IRepository<Feedback, int> feedbackRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public void Add(FeedbackViewModel feedbackVm)
        {
            _feedbackRepository.Add(_mapper.Map<FeedbackViewModel, Feedback>(feedbackVm));
        }

        public void Delete(int id)
        {
            _feedbackRepository.Remove(id);
        }

        public List<FeedbackViewModel> GetAll()
        {
            return _feedbackRepository
                .FindAll()
                .ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _feedbackRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            int totalRow = query.Count();

            var data = query
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<FeedbackViewModel>
            {
                Results = data.ProjectTo<FeedbackViewModel>(_mapper.ConfigurationProvider).ToList(),
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRow
            };
        }

        public FeedbackViewModel GetById(int id)
        {
            return _mapper.Map<Feedback, FeedbackViewModel>(_feedbackRepository.FindById(id));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FeedbackViewModel feedbackVm)
        {
            _feedbackRepository.Update(_mapper.Map<FeedbackViewModel, Feedback>(feedbackVm));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
