using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class ProductTag : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public string TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }
    }
}
