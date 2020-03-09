using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AdvertistmentPage
    {
        public string Name { get; set; }

        public List<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }
}
