using olShop.Data.Enums;
using System.Collections.Generic;

namespace olShop.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        public List<PermissionViewModel> Permissions { get; set; }
    }
}
