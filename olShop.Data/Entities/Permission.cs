using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class Permission : DomainEntity<int>
    {
        public Guid RoleId { get; set; }

        public string FunctionId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public AppRole AppRole { get; set; }

        public Function Function { get; set; }

        public Permission()
        {

        }

        public Permission(Guid roleId, string functionId, bool canCreate, bool canRead,
            bool canUpdate, bool canDelete)
        {
            this.RoleId = roleId;
            this.FunctionId = functionId;
            this.CanCreate = canCreate;
            this.CanRead = canRead;
            this.CanUpdate = canUpdate;
            this.CanDelete = canDelete;
        }
    }
}
