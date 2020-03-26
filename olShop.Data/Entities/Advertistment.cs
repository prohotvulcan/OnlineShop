using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class Advertistment : DomainEntity<int>, ISwitchable, ISortable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string PositionId { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int SortOrder { get; set; }

        public AdvertistmentPosition AdvertistmentPosition { get; set; }

    }
}
