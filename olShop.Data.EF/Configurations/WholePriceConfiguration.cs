using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class WholePriceConfiguration : IEntityTypeConfiguration<WholePrice>
    {
        public void Configure(EntityTypeBuilder<WholePrice> builder)
        {
            builder.ToTable("WholePrices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.HasOne(x => x.Product)
                .WithMany(y => y.WholePrices)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
