using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.ToTable("ProductTags");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TagId)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            builder.Property(x => x.TagId).HasMaxLength(50);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.ProductTags)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Tag)
                .WithMany(y => y.ProductTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}
