using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;

namespace olShop.Data.Entities
{
    public class SystemConfig : DomainEntity<string>, ISwitchable
    {
        public string Name { get; set; }

        public string Value1 { get; set; }

        public int? Value2 { get; set; }

        public bool? Value3 { get; set; }

        public DateTime? Value4 { get; set; }

        public decimal? Value5 { get; set; }

        public Status Status { get; set; }
    }
}
