using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using olShop.Application.Interfaces;
using olShop.WebApp.Models;

namespace olShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        private readonly IBlogService _blogService;
        private readonly ICommonService _commonService;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IProductService productService,
            IProductCategoryService productCategoryService,
            IBlogService blogService,
            ICommonService commonService,
            IStringLocalizer<HomeController> localizer)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._blogService = blogService;
            this._commonService = commonService;
            this._localizer = localizer;
        }

        public IActionResult Index()
        {
            var title = _localizer["Title"];
            var culture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            var homeVm = new HomeViewModel
            {
                HomeCategories = _productCategoryService.GetHomeCategories(5),
                HotProducts = _productService.GetHotProduct(5),
                TopSellProducts = _productService.GetLastest(5),
                LatestBlogs = _blogService.GetLastest(5),
                HomeSlides = _commonService.GetSlides("top")
            };
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return LocalRedirect(returnUrl);
        }
    }
}
