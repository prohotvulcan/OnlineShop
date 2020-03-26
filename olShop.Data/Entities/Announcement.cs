using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Announcement : DomainEntity<string>, IDateTracking, ISwitchable
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public AppUser AppUser { get; set; }

        public List<AnnouncementUser> AnnouncementUsers { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public Announcement()
        {
            this.AnnouncementUsers = new List<AnnouncementUser>();
        }

        public Announcement(string title, string content, Guid userId, Status status)
        {
            this.Title = title;
            this.UserId = userId;
            this.Content = content;
            this.Status = status;
        }
    }
}
