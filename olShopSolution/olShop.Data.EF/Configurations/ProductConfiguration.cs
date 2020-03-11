using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.CategoryId).IsRequired(true);

            builder.Property(x => x.Image).HasMaxLength(256);

            builder.Property(x => x.Price)
                .HasDefaultValue(0)
                .IsRequired(true);

            builder.Property(x => x.OriginalPrice).IsRequired();

            builder.Property(x => x.Description).HasMaxLength(256);

            builder.Property(x => x.Tags).HasMaxLength(256);

            builder.Property(x => x.Unit).HasMaxLength(256);

            builder.Property(x => x.SeoAlias).HasMaxLength(256);

            builder.Property(x => x.SeoKeywords).HasMaxLength(256);

            builder.Property(x => x.SeoDescription).HasMaxLength(256);

            builder.HasOne(x => x.ProductCategory)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
