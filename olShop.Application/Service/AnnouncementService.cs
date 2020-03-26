using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.System;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Dtos;
using System;
using System.Linq;

namespace olShop.Application.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement, string> _announcementRepository;
        private readonly IRepository<AnnouncementUser, int> _announcementUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnnouncementService(IRepository<Announcement, string> announcementRepository,
            IRepository<AnnouncementUser, int> announcementUserRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._announcementRepository = announcementRepository;
            this._announcementUserRepository = announcementUserRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public PagedResult<AnnouncementViewModel> GetAllUnreadPaging(Guid userId, int pageIndex, int pageSize)
        {
            var query = from x in _announcementRepository.FindAll()
                        join y in _announcementUserRepository.FindAll()
                        on x.Id equals y.AnnouncementId into xy
                        from announUser in xy.DefaultIfEmpty()
                        where announUser.HasRead == false
                        && (announUser.UserId == null || announUser.UserId == userId)
                        select x;
            int totalRow = query.Count();

            var model = query.OrderByDescending(x => x.DateCreated)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ProjectTo<AnnouncementViewModel>(_mapper.ConfigurationProvider)
                .ToList();

            return new PagedResult<AnnouncementViewModel>
            {
                Results = model,
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow
            };
        }

        public bool MarkAsRead(Guid userId, string id)
        {
            var announUser = _announcementUserRepository
                .FindSingle(x => x.AnnouncementId == id && x.UserId == userId);

            if (announUser == null)
            {
                _announcementUserRepository.Add(new AnnouncementUser
                {
                    AnnouncementId = id,
                    UserId = userId,
                    HasRead = true
                });
                return true;
            }
            else
            {
                if (announUser.HasRead == false)
                {
                    announUser.HasRead = true;
                    return true;
                }
            }
            return false;
        }
    }
}
