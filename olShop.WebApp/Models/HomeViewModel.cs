using olShop.Application.ViewModels.Blog;
using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using System.Collections.Generic;

namespace olShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> LatestBlogs { get; set; }
        public List<SlideViewModel> HomeSlides { get; set; }
        public List<ProductViewModel> HotProducts { get; set; }
        public List<ProductViewModel> TopSellProducts { get; set; }
        public List<ProductCategoryViewModel> HomeCategories { get; set; }

        public string Title { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
    }
}
