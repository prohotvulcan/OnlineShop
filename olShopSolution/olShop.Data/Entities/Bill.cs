using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class Bill : DomainEntity<int>, IDateTracking, ISwitchable
    {
        public Bill()
        {

        }

        public Bill(string customerName, string customerAddress, 
            string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid? customerId)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerMobile = customerMobile;
            this.CustomerMessage = customerMessage;
            this.BillStatus = billStatus;
            this.PaymentMethod = paymentMethod;
            this.Status = status;
            this.CustomerId = customerId;
        }

        public Bill(int id, string customerName, string customerAddress,
            string customerMobile, string customerMessage,
            BillStatus billStatus, PaymentMethod paymentMethod, Status status, Guid? customerId)
        {
            Id = id;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMobile = customerMobile;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerMessage { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public BillStatus BillStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; } = Status.Active;
        public Guid? CustomerId { get; set; }

        public AppUser User { get; set; }


    }
}
