using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Description).HasMaxLength(250);

            builder.Property(x => x.Image)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Url).HasMaxLength(250);

            builder.Property(x => x.GroupAlias)
                .HasMaxLength(25)
                .IsRequired(true);
        }
    }
}
