using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ProductQuantityConfiguration : IEntityTypeConfiguration<ProductQuantity>
    {
        public void Configure(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.ToTable("ProductQuantities");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.ProductQuantities)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Size)
                .WithMany(y => y.ProductQuantities)
                .HasForeignKey(x => x.SizeId);

            builder.HasOne(x => x.Color)
                .WithMany(y => y.ProductQuantities)
                .HasForeignKey(x => x.ColorId);
        }
    }
}
