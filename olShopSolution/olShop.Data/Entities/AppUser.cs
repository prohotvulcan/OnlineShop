using Microsoft.AspNetCore.Identity;
using olShop.Data.Enums;
using olShop.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public List<Announcement> Announcements { get; set; }

        public List<Bill> Bills { get; set; }

        public AppUser()
        {

        }

        public AppUser(Guid id, string fullName, string userName, string email,
            string phoneNumber, string avatar, Status status)
        {
            this.Id = id;
            this.FullName = fullName;
            this.UserName = userName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Avatar = avatar;
            this.Status = status;
        }

    }
}
