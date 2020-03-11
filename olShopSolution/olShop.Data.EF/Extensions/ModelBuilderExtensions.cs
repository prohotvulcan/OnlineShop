using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Utilities.Constants;
using System;

namespace olShop.Data.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // role
            var adminRoleId = new Guid("AF186D00-6D93-4721-AC73-46A8D968C8ED");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });

            // user
            var hasher = new PasswordHasher<AppUser>();
            var adminId = new Guid("A389BFC2-ED92-4FB5-8705-FD0CB5B48B48");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = adminId,
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "prohotvulcan@gmail.com",
                    NormalizedEmail = "prohotvulcan@gmail.com",
                    EmailConfirmed = true,
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active,
                    PasswordHash = hasher.HashPassword(null, "admin@123"),
                    Birthday = new DateTime(1993, 3, 3)
                });

            // user role
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid> 
            {
                RoleId = adminRoleId, 
                UserId = adminId 
            });

            // contact
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = CommonContants.DefaultContactId,
                    Address = "Mau Than - Xuan Khanh - Ninh Kieu - Can Tho",
                    Email = "onlineshop@gmail.com",
                    Name = "Online Shop",
                    Phone = "0961 313 760",
                    Status = Status.Active,
                    Website = "http://www.thoitranganhduc.com/",
                    Lat = 10.0287274,
                    Lng = 105.7763564
                });

            // function
            modelBuilder.Entity<Function>().HasData(
                new Function { Id = "SYSTEM", Name = "System", ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-desktop" },
                new Function { Id = "ROLE", Name = "Role", ParentId = "SYSTEM", SortOrder = 1, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-home" },
                new Function { Id = "FUNCTION", Name = "Function", ParentId = "SYSTEM", SortOrder = 2, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-home" },
                new Function { Id = "USER", Name = "User", ParentId = "SYSTEM", SortOrder = 3, Status = Status.Active, URL = "/admin/user/index", IconCss = "fa-home" },
                new Function { Id = "ACTIVITY", Name = "Activity", ParentId = "SYSTEM", SortOrder = 4, Status = Status.Active, URL = "/admin/activity/index", IconCss = "fa-home" },
                new Function { Id = "ERROR", Name = "Error", ParentId = "SYSTEM", SortOrder = 5, Status = Status.Active, URL = "/admin/error/index", IconCss = "fa-home" },
                new Function { Id = "SETTING", Name = "Configuration", ParentId = "SYSTEM", SortOrder = 6, Status = Status.Active, URL = "/admin/setting/index", IconCss = "fa-home" },

                new Function { Id = "PRODUCT", Name = "Product Management", ParentId = null, SortOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-chevron-down" },
                new Function { Id = "PRODUCT_CATEGORY", Name = "Category", ParentId = "PRODUCT", SortOrder = 1, Status = Status.Active, URL = "/admin/productcategory/index", IconCss = "fa-chevron-down" },
                new Function { Id = "PRODUCT_LIST", Name = "Product", ParentId = "PRODUCT", SortOrder = 2, Status = Status.Active, URL = "/admin/product/index", IconCss = "fa-chevron-down" },
                new Function { Id = "BILL", Name = "Bill", ParentId = "PRODUCT", SortOrder = 3, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-chevron-down" },

                new Function { Id = "CONTENT", Name = "Content", ParentId = null, SortOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-table" },
                new Function { Id = "BLOG", Name = "Blog", ParentId = "CONTENT", SortOrder = 1, Status = Status.Active, URL = "/admin/blog/index", IconCss = "fa-table" },
                new Function { Id = "PAGE", Name = "Page", ParentId = "CONTENT", SortOrder = 2, Status = Status.Active, URL = "/admin/page/index", IconCss = "fa-table" },

                new Function { Id = "UTILITY", Name = "Utilities", ParentId = null, SortOrder = 4, Status = Status.Active, URL = "/", IconCss = "fa-clone" },
                new Function { Id = "FOOTER", Name = "Footer", ParentId = "UTILITY", SortOrder = 1, Status = Status.Active, URL = "/admin/footer/index", IconCss = "fa-clone" },
                new Function { Id = "FEEDBACK", Name = "Feedback", ParentId = "UTILITY", SortOrder = 2, Status = Status.Active, URL = "/admin/feedback/index", IconCss = "fa-clone" },
                new Function { Id = "ANNOUNCEMENT", Name = "Announcement", ParentId = "UTILITY", SortOrder = 3, Status = Status.Active, URL = "/admin/announcement/index", IconCss = "fa-clone" },
                new Function { Id = "CONTACT", Name = "Contact", ParentId = "UTILITY", SortOrder = 4, Status = Status.Active, URL = "/admin/contact/index", IconCss = "fa-clone" },
                new Function { Id = "SLIDE", Name = "Slide", ParentId = "UTILITY", SortOrder = 5, Status = Status.Active, URL = "/admin/slide/index", IconCss = "fa-clone" },
                new Function { Id = "ADVERTISMENT", Name = "Advertisment", ParentId = "UTILITY", SortOrder = 6, Status = Status.Active, URL = "/admin/advertistment/index", IconCss = "fa-clone" },

                new Function { Id = "REPORT", Name = "Report", ParentId = null, SortOrder = 5, Status = Status.Active, URL = "/", IconCss = "fa-bar-chart-o" },
                new Function { Id = "REVENUES", Name = "Revenue report", ParentId = "REPORT", SortOrder = 1, Status = Status.Active, URL = "/admin/report/revenues", IconCss = "fa-bar-chart-o" },
                new Function { Id = "ACCESS", Name = "Visitor Report", ParentId = "REPORT", SortOrder = 2, Status = Status.Active, URL = "/admin/report/visitor", IconCss = "fa-bar-chart-o" },
                new Function { Id = "READER", Name = "Reader Report", ParentId = "REPORT", SortOrder = 3, Status = Status.Active, URL = "/admin/report/reader", IconCss = "fa-bar-chart-o" });

            // footer
            modelBuilder.Entity<Footer>().HasData(new Footer { Id = CommonContants.DefaultFooterId, Content = "Footer" });

            // color
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Black", Code = "#000000" },
                new Color { Id = 2, Name = "White", Code = "#FFFFFF" },
                new Color { Id = 3, Name = "Red", Code = "#ff0000" },
                new Color { Id = 4, Name = "Blue", Code = "#1000ff" });

            // advertistment page
            modelBuilder.Entity<AdvertistmentPage>().HasData(
                new AdvertistmentPage { Id = "home", Name = "Home" },
                new AdvertistmentPage { Id = "product-cate", Name = "Product category" },
                new AdvertistmentPage { Id = "product-detail", Name = "Product detail" });

            // advertistment position
            modelBuilder.Entity<AdvertistmentPosition>().HasData(
                new AdvertistmentPosition { Id = "home-left", PageId = "home", Name = "Bên trái" },
                new AdvertistmentPosition { Id = "product-cate-left", PageId = "product-cate", Name = "Bên trái" },
                new AdvertistmentPosition { Id = "product-detail-left", PageId = "product-detail", Name = "Bên trái" });

            // slide
            modelBuilder.Entity<Slide>().HasData(
                new Slide { Id = 1, Name = "Slide 1", Image = "/client-side/images/slider/slide-1.jpg", Url = "#", DisplayOrder = 0, GroupAlias = "top", Status = true },
                new Slide { Id = 2, Name = "Slide 2", Image = "/client-side/images/slider/slide-2.jpg", Url = "#", DisplayOrder = 1, GroupAlias = "top", Status = true },
                new Slide { Id = 3, Name = "Slide 3", Image = "/client-side/images/slider/slide-3.jpg", Url = "#", DisplayOrder = 2, GroupAlias = "top", Status = true },

                new Slide { Id = 4, Name = "Slide 1", Image = "/client-side/images/brand1.png", Url = "#", DisplayOrder = 1, GroupAlias = "brand", Status = true },
                new Slide { Id = 5, Name = "Slide 2", Image = "/client-side/images/brand2.png", Url = "#", DisplayOrder = 2, GroupAlias = "brand", Status = true },
                new Slide { Id = 6, Name = "Slide 3", Image = "/client-side/images/brand3.png", Url = "#", DisplayOrder = 3, GroupAlias = "brand", Status = true },
                new Slide { Id = 7, Name = "Slide 4", Image = "/client-side/images/brand4.png", Url = "#", DisplayOrder = 4, GroupAlias = "brand", Status = true },
                new Slide { Id = 8, Name = "Slide 5", Image = "/client-side/images/brand5.png", Url = "#", DisplayOrder = 5, GroupAlias = "brand", Status = true },
                new Slide { Id = 9, Name = "Slide 6", Image = "/client-side/images/brand6.png", Url = "#", DisplayOrder = 6, GroupAlias = "brand", Status = true },
                new Slide { Id = 10, Name = "Slide 7", Image = "/client-side/images/brand7.png", Url = "#", DisplayOrder = 7, GroupAlias = "brand", Status = true },
                new Slide { Id = 11, Name = "Slide 8", Image = "/client-side/images/brand8.png", Url = "#", DisplayOrder = 8, GroupAlias = "brand", Status = true },
                new Slide { Id = 12, Name = "Slide 9", Image = "/client-side/images/brand9.png", Url = "#", DisplayOrder = 9, GroupAlias = "brand", Status = true },
                new Slide { Id = 13, Name = "Slide 10", Image = "/client-side/images/brand10.png", Url = "#", DisplayOrder = 10, GroupAlias = "brand", Status = true },
                new Slide { Id = 14, Name = "Slide 11", Image = "/client-side/images/brand11.png", Url = "#", DisplayOrder = 11, GroupAlias = "brand", Status = true });

            // size
            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "XXL" },
                new Size { Id = 2, Name = "XL" },
                new Size { Id = 3, Name = "L" },
                new Size { Id = 4, Name = "M" },
                new Size { Id = 5, Name = "S" },
                new Size { Id = 6, Name = "XS" });

            // product category
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    Name = "Men shirt",
                    SeoAlias = "men-shirt",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 1
                },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Women shirt",
                    SeoAlias = "women-shirt",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 2
                },
                new ProductCategory
                {
                    Id = 3,
                    Name = "Men shoes",
                    SeoAlias = "men-shoes",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 3
                },
                new ProductCategory
                {
                    Id = 4,
                    Name = "Woment shoes",
                    SeoAlias = "women-shoes",
                    ParentId = null,
                    Status = Status.Active,
                    SortOrder = 4
                });

            // product
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Product 1", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-1", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 2, CategoryId = 1, Name = "Product 2", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-2", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 3, CategoryId = 1, Name = "Product 3", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-3", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 4, CategoryId = 1, Name = "Product 4", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-4", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 5, CategoryId = 1, Name = "Product 5", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-5", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                new Product { Id = 6, CategoryId = 2, Name = "Product 6", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-6", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 7, CategoryId = 2, Name = "Product 7", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-7", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 8, CategoryId = 2, Name = "Product 8", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-8", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 9, CategoryId = 2, Name = "Product 9", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-9", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 10, CategoryId = 2, Name = "Product 10", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-10", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                new Product { Id = 11, CategoryId = 3, Name = "Product 11", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-11", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 12, CategoryId = 3, Name = "Product 12", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-12", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 13, CategoryId = 3, Name = "Product 13", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-13", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 14, CategoryId = 3, Name = "Product 14", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-14", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 15, CategoryId = 3, Name = "Product 15", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-15", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                new Product { Id = 16, CategoryId = 4, Name = "Product 16", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-16", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 17, CategoryId = 4, Name = "Product 17", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-17", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 18, CategoryId = 4, Name = "Product 18", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-18", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 19, CategoryId = 4, Name = "Product 19", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-19", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                new Product { Id = 20, CategoryId = 4, Name = "Product 20", DateCreated = DateTime.Now, Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-20", Price = 1000, Status = Status.Active, OriginalPrice = 1000 });

            // system config
            modelBuilder.Entity<SystemConfig>().HasData(
                new SystemConfig
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = "Online Shop home",
                    Status = Status.Active
                },
                new SystemConfig
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "shopping, sales",
                    Status = Status.Active
                },
                new SystemConfig
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home",
                    Status = Status.Active
                });

        }
    }
}
