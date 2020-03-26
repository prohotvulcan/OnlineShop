using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class ProductImage : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }
    }
}
