using olShop.Infrastructure.SharedKernel;

namespace olShop.Data.Entities
{
    public class BillDetail : DomainEntity<int>
    {
        public int BillId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        public Bill Bill { get; set; }

        public Product Product { get; set; }

        public Color Color { get; set; }

        public Size Size { get; set; }

        public BillDetail()
        {

        }

        public BillDetail(int id, int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            this.Id = id;
            this.BillId = billId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
            this.ColorId = colorId;
            this.SizeId = sizeId;
        }

        public BillDetail(int billId, int productId, int quantity, decimal price, int colorId, int sizeId)
        {
            this.BillId = billId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
            this.ColorId = colorId;
            this.SizeId = sizeId;
        }
    }
}
