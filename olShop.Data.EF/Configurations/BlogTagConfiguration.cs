﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.ToTable("BlogTags");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.TagId)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.HasOne(x => x.Blog)
                .WithMany(y => y.BlogTags)
                .HasForeignKey(x => x.BlogId);

            builder.HasOne(x => x.Tag)
                .WithMany(y => y.BlogTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}
