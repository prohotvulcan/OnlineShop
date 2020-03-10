using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetails");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Bill)
                .WithMany(y => y.BillDetails)
                .HasForeignKey(x => x.BillId);

            builder.HasOne(x => x.Product)
                .WithMany(y => y.BillDetails)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Color)
                .WithMany(y => y.BillDetails)
                .HasForeignKey(x => x.ColorId);

            builder.HasOne(x => x.Size)
                .WithMany(y => y.BillDetails)
                .HasForeignKey(x => x.SizeId);
        }
    }
}
