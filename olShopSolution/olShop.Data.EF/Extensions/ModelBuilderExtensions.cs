using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace olShop.Data.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var adminRoleId = new Guid("AF186D00-6D93-4721-AC73-46A8D968C8ED");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });

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
        }
    }
}
