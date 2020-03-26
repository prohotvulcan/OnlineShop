using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();
        }
    }
}
