using System;

namespace olShop.Application.ViewModels.System
{
    public class AnnouncementUserViewModel
    {
        public int Id { get; set; }

        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        public AnnouncementViewModel Announcement { get; set; }
    }
}
