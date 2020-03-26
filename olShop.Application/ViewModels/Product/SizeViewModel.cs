using System.Collections.Generic;

namespace olShop.Application.ViewModels.Product
{
    public class SizeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<BillDetailViewModel> BillDetails { get; set; }

        public List<ProductQuantityViewModel> ProductQuantities { get; set; }
    }
}
