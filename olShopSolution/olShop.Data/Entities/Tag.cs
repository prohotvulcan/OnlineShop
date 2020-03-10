using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Tag : DomainEntity<string>
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
