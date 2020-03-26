using olShop.Application.ViewModels.Product;
using olShop.Data.Enums;
using System;
using System.Collections.Generic;

namespace olShop.Application.ViewModels.System
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            this.Roles = new List<string>();
        }

        public Guid? Id { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Email { set; get; }

        public string Password { set; get; }

        public string UserName { set; get; }

        public string Address { get; set; }

        public string PhoneNumber { set; get; }

        public decimal Balance { get; set; }

        public string Gender { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public List<AnnouncementViewModel> Announcements { get; set; }

        public List<BillViewModel> Bills { get; set; }

        public List<string> Roles { get; set; }
    }
}
