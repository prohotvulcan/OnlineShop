using olShop.Data.Enums;
using olShop.Data.Interfaces;
using olShop.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class Blog : DomainEntity<int>, IDateTracking, ISwitchable, IHasSeoMetaData
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public List<BlogTag> BlogTags { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public Blog()
        {

        }

        public Blog(string name, string thumbnailImage,
           string description, string content, bool? homeFlag, bool? hotFlag,
           string tags, Status status, string seoPageTitle,
           string seoAlias, string seoMetaKeyword,
           string seoMetaDescription)
        {
            this.Name = name;
            this.Image = thumbnailImage;
            this.Description = description;
            this.Content = content;
            this.HomeFlag = homeFlag;
            this.HotFlag = hotFlag;
            this.Tags = tags;
            this.Status = status;
            this.SeoPageTitle = seoPageTitle;
            this.SeoAlias = seoAlias;
            this.SeoKeywords = seoMetaKeyword;
            this.SeoDescription = seoMetaDescription;
        }

        public Blog(int id, string name, string thumbnailImage,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            this.Id = id;
            this.Name = name;
            this.Image = thumbnailImage;
            this.Description = description;
            this.Content = content;
            this.HomeFlag = homeFlag;
            this.HotFlag = hotFlag;
            this.Tags = tags;
            this.Status = status;
            this.SeoPageTitle = seoPageTitle;
            this.SeoAlias = seoAlias;
            this.SeoKeywords = seoMetaKeyword;
            this.SeoDescription = seoMetaDescription;
        }
    }
}
