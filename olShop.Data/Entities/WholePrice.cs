using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class WholePrice : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public int FromQuantity { get; set; }

        public int ToQuantity { get; set; }

        public decimal Price { get; set; }

        public Product Product { get; set; }
    }
}
