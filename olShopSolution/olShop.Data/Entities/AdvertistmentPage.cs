using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AdvertistmentPage : DomainEntity<string>
    {
        public string Name { get; set; }

        public List<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
