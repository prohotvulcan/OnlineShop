using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class Feedback : DomainEntity<int>, IDateTracking, ISwitchable
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Feedback()
        {

        }

        public Feedback(int id, string name, string email, string message, Status status)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Message = message;
            this.Status = Status;
        }
    }
}
