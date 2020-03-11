using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Size : DomainEntity<int>
    {
        public string Name { get; set; }

        public List<BillDetail> BillDetails { get; set; }

        public List<ProductQuantity> ProductQuantities { get; set; }
    }
}
