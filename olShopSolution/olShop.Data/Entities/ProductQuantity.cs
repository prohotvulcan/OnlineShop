﻿using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class ProductQuantity : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }
    }
}
