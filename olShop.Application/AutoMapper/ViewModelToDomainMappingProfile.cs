using AutoMapper;
using olShop.Application.ViewModels.Blog;
using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using olShop.Application.ViewModels.System;
using olShop.Data.Entities;
using System;

namespace olShop.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(x => new Product
                (
                    x.Name,
                    x.CategoryId,
                    x.Image,
                    x.Price,
                    x.OriginalPrice,
                    x.PromotionPrice,
                    x.Description,
                    x.Content,
                    x.HomeFlag,
                    x.HotFlag,
                    x.Tags,
                    x.Unit,
                    x.Status,
                    x.SeoPageTitle,
                    x.SeoAlias,
                    x.SeoKeywords,
                    x.SeoDescription
                ));

            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(x => new ProductCategory
                (
                    x.Name,
                    x.Description,
                    x.ParentId,
                    x.HomeOrder,
                    x.Image,
                    x.HomeFlag,
                    x.SortOrder,
                    x.Status,
                    x.SeoPageTitle,
                    x.SeoAlias,
                    x.SeoKeywords,
                    x.SeoDescription
                ));

            CreateMap<BillViewModel, Bill>()
                .ConstructUsing(x => new Bill
                (
                    x.Id,
                    x.CustomerName,
                    x.CustomerAddress,
                    x.CustomerMobile,
                    x.CustomerMessage,
                    x.BillStatus,
                    x.PaymentMethod,
                    x.Status,
                    x.CustomerId
                ));

            CreateMap<BillDetailViewModel, BillDetail>()
                .ConstructUsing(x => new BillDetail
                (
                    x.Id,
                    x.BillId,
                    x.ProductId,
                    x.Quantity,
                    x.Price,
                    x.ColorId,
                    x.SizeId
                ));

            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(x => new AppUser
                (
                    x.Id.GetValueOrDefault(Guid.Empty),
                    x.FullName,
                    x.UserName,
                    x.Email,
                    x.PhoneNumber,
                    x.Avatar,
                    x.Status
                ));

            CreateMap<PermissionViewModel, Permission>()
                .ConstructUsing(x => new Permission
                (
                    x.RoleId,
                    x.FunctionId,
                    x.CanCreate,
                    x.CanRead,
                    x.CanUpdate,
                    x.CanDelete
                ));

            CreateMap<ContactViewModel, Contact>()
                .ConstructUsing(x => new Contact
                (
                    x.Id,
                    x.Name,
                    x.Phone,
                    x.Email,
                    x.Website,
                    x.Address,
                    x.Other,
                    x.Lng,
                    x.Lat,
                    x.Status
                ));

            CreateMap<FeedbackViewModel, Feedback>()
                .ConstructUsing(x => new Feedback
                (
                    x.Id,
                    x.Name,
                    x.Email,
                    x.Message,
                    x.Status
                ));

            CreateMap<PageViewModel, Page>()
                .ConstructUsing(x => new Page
                (
                    x.Id,
                    x.Name,
                    x.Alias,
                    x.Content,
                    x.Status
                ));

            CreateMap<AnnouncementViewModel, Announcement>()
                .ConstructUsing(x => new Announcement
                (
                    x.Title,
                    x.Content,
                    x.UserId,
                    x.Status
                ));

            CreateMap<AnnouncementUserViewModel, AnnouncementUser>()
                .ConstructUsing(x => new AnnouncementUser
                (
                    x.AnnouncementId,
                    x.UserId,
                    x.HasRead
                ));
        }
    }
}
