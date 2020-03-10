using olShop.Infrastructure.SharedKernel;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Tag : DomainEntity<string>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public List<BlogTag> BlogTags { get; set; }
    }
}
