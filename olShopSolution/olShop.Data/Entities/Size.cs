using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Size : DomainEntity<int>
    {
        public string Name { get; set; }
    }
}
