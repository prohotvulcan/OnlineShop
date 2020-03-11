using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class BlogTag : DomainEntity<int>
    {
        public int BlogId { get; set; }

        public string TagId { get; set; }

        public Blog Blog { get; set; }

        public Tag Tag { get; set; }
    }
}
