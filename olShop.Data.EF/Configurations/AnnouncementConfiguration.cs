using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(x => x.Title).HasMaxLength(250);

            builder.Property(x => x.Content).HasMaxLength(250);

            builder.HasOne(x => x.AppUser)
                .WithMany(y => y.Announcements)
                .HasForeignKey(x => x.UserId);
        }
    }
}
