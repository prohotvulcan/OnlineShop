using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Color : DomainEntity<int>
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
