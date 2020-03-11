using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Footer : DomainEntity<string>
    {
        public string Content { get; set; }
    }
}
