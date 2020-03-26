using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class AnnouncementUser : DomainEntity<int>
    {
        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        public Announcement Announcement { get; set; }

        public AnnouncementUser()
        {

        }

        public AnnouncementUser(string announcementId, Guid userId, bool? hasRead)
        {
            this.AnnouncementId = announcementId;
            this.UserId = userId;
            this.HasRead = hasRead;
        }
    }
}
