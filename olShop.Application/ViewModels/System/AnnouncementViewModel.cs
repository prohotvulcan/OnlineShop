using olShop.Data.Enums;
using System;
using System.Collections.Generic;

namespace olShop.Application.ViewModels.System
{
    public class AnnouncementViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public AppUserViewModel AppUser { get; set; }

        public List<AnnouncementUserViewModel> AnnouncementUsers { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }
    }
}
