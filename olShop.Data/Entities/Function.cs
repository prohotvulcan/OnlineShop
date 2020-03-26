using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Function : DomainEntity<string>, ISortable, ISwitchable
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        public List<Permission> Permissions { get; set; }

        public Function()
        {

        }

        public Function(string name, string url, string parentId, string iconCss, int sortOrder)
        {
            this.Name = name;
            this.URL = url;
            this.ParentId = parentId;
            this.IconCss = iconCss;
            this.SortOrder = sortOrder;
            this.Status = Status.Active;
        }
    }
}
