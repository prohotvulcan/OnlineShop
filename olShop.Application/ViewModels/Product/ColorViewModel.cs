using System.Collections.Generic;

namespace olShop.Application.ViewModels.Product
{
    public class ColorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public List<BillDetailViewModel> BillDetails { get; set; }

        public List<ProductQuantityViewModel> ProductQuantities { get; set; }
    }
}
