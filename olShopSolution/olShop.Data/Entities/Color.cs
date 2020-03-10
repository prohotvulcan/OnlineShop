using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Color : DomainEntity<int>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public List<BillDetail> BillDetails { get; set; }
    }
}
