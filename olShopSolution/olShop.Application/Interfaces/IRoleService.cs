using olShop.Application.ViewModels.System;
using olShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olShop.Application.Interfaces
{
    public interface IRoleService
    {
        Task<bool> AddAsync(AnnouncementViewModel announcementVm,
            List<AnnouncementUserViewModel> announcementUserVms,
            AppRoleViewModel appRoleVm);

        Task DeleteAsync(Guid id);

        Task<List<AppRoleViewModel>> GetAllAsync();

        PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppRoleViewModel> GetById(int id);

        Task UpdateAsync(AppRoleViewModel appRoleVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissionVm, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
