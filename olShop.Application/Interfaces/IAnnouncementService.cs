using olShop.Application.ViewModels.System;
using olShop.Utilities.Dtos;
using System;

namespace olShop.Application.Interfaces
{
    public interface IAnnouncementService
    {
        PagedResult<AnnouncementViewModel> GetAllUnreadPaging(Guid userId, int pageIndex, int pageSize);

        bool MarkAsRead(Guid userId, string id);
    }
}
