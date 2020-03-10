using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Product : DomainEntity<int>, IDateTracking, ISwitchable, IHasSeoMetaData
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public string Unit { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public List<ProductTag> ProductTags { get; set; }

        public List<BillDetail> BillDetails { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public Product()
        {
            this.ProductTags = new List<ProductTag>();
        }

        public Product(string name, int categoryId, string thumbnailImage,
            decimal price, decimal originalPrice, decimal? promotionPrice,
            string description, string content, bool? homeFlag, bool? hotFlag,
            string tags, string unit, Status status, string seoPageTitle,
            string seoAlias, string seoMetaKeyword,
            string seoMetaDescription)
        {
            this.Name = name;
            this.CategoryId = categoryId;
            this.Image = thumbnailImage;
            this.Price = price;
            this.OriginalPrice = originalPrice;
            this.PromotionPrice = promotionPrice;
            this.Description = description;
            this.Content = content;
            this.HomeFlag = homeFlag;
            this.HotFlag = hotFlag;
            this.Tags = tags;
            this.Unit = unit;
            this.Status = status;
            this.SeoPageTitle = seoPageTitle;
            this.SeoAlias = seoAlias;
            this.SeoKeywords = seoMetaKeyword;
            this.SeoDescription = seoMetaDescription;
            this.ProductTags = new List<ProductTag>();

        }

        public Product(int id, string name, int categoryId, string thumbnailImage,
             decimal price, decimal originalPrice, decimal? promotionPrice,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, string unit, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            this.Id = id;
            this.Name = name;
            this.CategoryId = categoryId;
            this.Image = thumbnailImage;
            this.Price = price;
            this.OriginalPrice = originalPrice;
            this.PromotionPrice = promotionPrice;
            this.Description = description;
            this.Content = content;
            this.HomeFlag = homeFlag;
            this.HotFlag = hotFlag;
            this.Tags = tags;
            this.Unit = unit;
            this.Status = status;
            this.SeoPageTitle = seoPageTitle;
            this.SeoAlias = seoAlias;
            this.SeoKeywords = seoMetaKeyword;
            this.SeoDescription = seoMetaDescription;
            this.ProductTags = new List<ProductTag>();
        }
    }
}
