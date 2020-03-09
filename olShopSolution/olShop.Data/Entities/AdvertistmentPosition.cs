﻿using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AdvertistmentPosition
    {
        public string PageId { get; set; }

        public string Name { get; set; }

        public Advertistment Advertistment { get; set; }

        public List<Advertistment> Advertistments { get; set; }
    }
}
