using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : IEntityTypeConfiguration<AdvertistmentPosition>
    {
        public void Configure(EntityTypeBuilder<AdvertistmentPosition> builder)
        {
            builder.ToTable("AdvertistmentPositions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(20).IsRequired();

            builder.Property(x => x.PageId).HasMaxLength(20);

            builder.Property(x => x.Name).HasMaxLength(250);

            builder.HasOne(x => x.AdvertistmentPage)
                .WithMany(y => y.AdvertistmentPositions)
                .HasForeignKey(x => x.PageId);
        }
    }
}
