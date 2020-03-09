using olShop.Data.Enums;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Advertistment
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

        public List<AdvertistmentPosition> AdvertistmentPositions { get; set; }

    }
}
