using Microsoft.AspNetCore.Mvc.Rendering;
using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using System.Collections.Generic;

namespace olShop.WebApp.Models.ProductViewModels
{
    public class DetailViewModel
    {
        public ProductViewModel Product { get; set; }

        public bool Available { get; set; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }

        public List<ProductViewModel> UpsellProducts { get; set; }

        public List<ProductViewModel> LastestProducts { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<SelectListItem> Colors { get; set; }

        public List<SelectListItem> Sizes { get; set; }
    }
}
