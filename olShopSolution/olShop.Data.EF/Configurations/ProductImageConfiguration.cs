using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path).HasMaxLength(250);

            builder.Property(x => x.Caption).HasMaxLength(250);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.ProductImages)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
