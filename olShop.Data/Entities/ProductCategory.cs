using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ISwitchable, ISortable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public List<Product> Products { get; set; }

        public ProductCategory()
        {
            this.Products = new List<Product>();
        }

        public ProductCategory(string name, string description, int? parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle,
            string seoAlias, string seoKeywords, string seoDescription)
        {
            this.Name = name;
            this.Description = description;
            this.ParentId = parentId;
            this.HomeOrder = homeOrder;
            this.Image = image;
            this.HomeFlag = homeFlag;
            this.SortOrder = sortOrder;
            this.Status = status;
            this.SeoPageTitle = seoPageTitle;
            this.SeoAlias = seoAlias;
            this.SeoKeywords = seoKeywords;
            this.SeoDescription = seoDescription;
        }
    }
}
