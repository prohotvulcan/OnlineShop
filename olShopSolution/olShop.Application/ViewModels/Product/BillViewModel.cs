using olShop.Application.ViewModels.System;
using olShop.Data.Enums;
using System;
using System.Collections.Generic;

namespace olShop.Application.ViewModels.Product
{
    public class BillViewModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerMobile { get; set; }

        public string CustomerMessage { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public BillStatus BillStatus { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public Guid? CustomerId { get; set; }

        public List<BillDetailViewModel> BillDetails { get; set; }

        public AppUserViewModel User { get; set; }
    }
}
