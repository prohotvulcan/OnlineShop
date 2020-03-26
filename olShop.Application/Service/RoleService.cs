using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.System;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olShop.Application.Service
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IRepository<Function, string> _functionRepository;
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IRepository<Announcement, string> _announRepository;
        private readonly IRepository<AnnouncementUser, int> _announUserRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RoleService(RoleManager<AppRole> roleManager,
            IRepository<Function, string> functionRepository,
            IRepository<Permission, int> permissionRepository,
            IRepository<Announcement, string> announRepository,
            IRepository<AnnouncementUser, int> announUserRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._roleManager = roleManager;
            this._functionRepository = functionRepository;
            this._permissionRepository = permissionRepository;
            this._announRepository = announRepository;
            this._announUserRepository = announUserRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> AddAsync(AnnouncementViewModel announcementVm, 
            List<AnnouncementUserViewModel> announcementUserVms, AppRoleViewModel appRoleVm)
        {
            var role = new AppRole
            {
                Name = appRoleVm.Name,
                Description = appRoleVm.Description
            };

            var result = await _roleManager.CreateAsync(role);
            var announcement = _mapper.Map<AnnouncementViewModel, Announcement>(announcementVm);
            _announRepository.Add(announcement);

            foreach (var userVm in announcementUserVms)
            {
                var user = _mapper.Map<AnnouncementUserViewModel, AnnouncementUser>(userVm);
                _announUserRepository.Add(user);
            }
            _unitOfWork.Commit();
            return result.Succeeded;
        }

        public async Task<bool> CheckPermission(string functionId, string action, string[] roles)
        {
            var functions = _functionRepository.FindAll();
            var permissions = _permissionRepository.FindAll();

            var query = from x in functions
                        join y in permissions on x.Id equals y.FunctionId
                        join z in _roleManager.Roles on y.RoleId equals z.Id
                        where roles.Contains(z.Name) && x.Id == functionId
                            && ((y.CanCreate && action == "Create")
                            || (y.CanDelete && action == "Delete")
                            || (y.CanRead && action == "Read")
                            || (y.CanUpdate && action == "Update"))
                        select y;

            return await query.AnyAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<List<AppRoleViewModel>> GetAllAsync()
        {
            return await _roleManager.Roles.ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            var query = _roleManager.Roles;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            int totalRow = query.Count();
            var data = query.Skip((page - 1) * pageSize).Take(pageSize);

            return new PagedResult<AppRoleViewModel>
            {
                Results = data.ProjectTo<AppRoleViewModel>(_mapper.ConfigurationProvider).ToList(),
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public async Task<AppRoleViewModel> GetById(Guid id)
        {
            return _mapper.Map<AppRole, AppRoleViewModel>(await _roleManager.FindByIdAsync(id.ToString()));
        }

        public List<PermissionViewModel> GetListFunctionWithRole(Guid roleId)
        {
            var functions = _functionRepository.FindAll();
            var permissions = _permissionRepository.FindAll();

            var query = from x in functions
                        join y in permissions on x.Id equals y.FunctionId into xy
                        from y in xy.DefaultIfEmpty()
                        where y != null && y.RoleId == roleId
                        select new PermissionViewModel
                        {
                            RoleId = roleId,
                            FunctionId = y.FunctionId,
                            CanCreate = y != null ? y.CanCreate : false,
                            CanDelete = y != null ? y.CanDelete : false,
                            CanRead = y != null ? y.CanRead : false,
                            CanUpdate = y != null ? y.CanUpdate : false
                        };

            return query.ToList();
        }

        public void SavePermission(List<PermissionViewModel> permissionVm, Guid roleId)
        {
            var permissions = _mapper.Map<List<PermissionViewModel>, List<Permission>>(permissionVm);
            var oldPermissions = _permissionRepository.FindAll(x => x.RoleId == roleId).ToList();

            if (oldPermissions.Count() > 0)
            {
                _permissionRepository.RemoveMultiple(oldPermissions);
            }

            foreach (var p in permissions)
            {
                _permissionRepository.Add(p);
            }
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(AppRoleViewModel appRoleVm)
        {
            var role = await _roleManager.FindByIdAsync(appRoleVm.Id.ToString());
            role.Description = appRoleVm.Description;
            role.Name = appRoleVm.Name;
            await _roleManager.UpdateAsync(role);
        }
    }
}
