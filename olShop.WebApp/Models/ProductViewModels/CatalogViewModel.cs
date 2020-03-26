using Microsoft.AspNetCore.Mvc.Rendering;
using olShop.Application.ViewModels.Product;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.WebApp.Models.ProductViewModels
{
    public class CatalogViewModel
    {
        public PagedResult<ProductViewModel> Data { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public string SortType { get; set; }

        public int? PageSize { get; set; }

        public List<SelectListItem> SortTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "lastest", Text = "Lastest"},
            new SelectListItem { Value = "price", Text = "Price" },
            new SelectListItem { Value = "name", Text = "Name" }
        };

        public List<SelectListItem> PageSizes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "12", Text = "12" },
            new SelectListItem { Value = "24", Text = "24" },
            new SelectListItem { Value = "48", Text = "48" }
        };
    }
}
