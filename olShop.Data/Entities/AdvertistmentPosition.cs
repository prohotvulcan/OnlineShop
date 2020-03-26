using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AdvertistmentPosition : DomainEntity<string>
    {
        public string PageId { get; set; }

        public string Name { get; set; }

        public AdvertistmentPage AdvertistmentPage { get; set; }

        public List<Advertistment> Advertistments { get; set; }
    }
}
