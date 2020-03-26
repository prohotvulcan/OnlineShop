using System;
using System.Collections.Generic;

namespace olShop.Application.ViewModels.System
{
    public class AppRoleViewModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<PermissionViewModel> Permissions { get; set; }
    }
}
