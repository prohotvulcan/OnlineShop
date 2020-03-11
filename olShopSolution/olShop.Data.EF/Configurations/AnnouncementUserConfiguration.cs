using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class AnnouncementUserConfiguration : IEntityTypeConfiguration<AnnouncementUser>
    {
        public void Configure(EntityTypeBuilder<AnnouncementUser> builder)
        {
            builder.ToTable("AnnouncementUsers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.AnnouncementId)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.HasOne(x => x.Announcement)
                .WithMany(y => y.AnnouncementUsers)
                .HasForeignKey(x => x.AnnouncementId);
        }
    }
}
