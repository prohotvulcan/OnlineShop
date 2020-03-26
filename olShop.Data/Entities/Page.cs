using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Page : DomainEntity<int>, ISwitchable
    {
        public string Name { get; set; }

        public string Alias { get; set; }

        public string Content { get; set; }

        public Status Status { get; set; }

        public Page()
        {

        }

        public Page(int id, string name, string alias, string content, Status status)
        {
            this.Id = id;
            this.Name = name;
            this.Alias = alias;
            this.Content = content;
            this.Status = status;
        }
    }
}
