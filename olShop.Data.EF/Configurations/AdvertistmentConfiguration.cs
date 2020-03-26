using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class AdvertistmentConfiguration : IEntityTypeConfiguration<Advertistment>
    {
        public void Configure(EntityTypeBuilder<Advertistment> builder)
        {
            builder.ToTable("Advertistments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(250);

            builder.Property(x => x.Description).HasMaxLength(250);

            builder.Property(x => x.Image).HasMaxLength(250);

            builder.Property(x => x.Url).HasMaxLength(250);

            builder.Property(x => x.PositionId).HasMaxLength(20);

            builder.HasOne(x => x.AdvertistmentPosition)
                .WithMany(y => y.Advertistments)
                .HasForeignKey(x => x.PositionId);
        }
    }
}
