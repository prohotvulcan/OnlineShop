using olShop.Data.Enums;
using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class Contact : DomainEntity<string>
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

        public string Other { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public Status Status { get; set; }

        public Contact()
        {

        }

        public Contact(string id, string name, string phone, string email,
            string website, string address, string other, double? longtitude, double? latitude, Status status)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Website = website;
            this.Address = address;
            this.Other = other;
            this.Lng = longtitude;
            this.Lat = latitude;
            this.Status = Status;
        }
    }
}
