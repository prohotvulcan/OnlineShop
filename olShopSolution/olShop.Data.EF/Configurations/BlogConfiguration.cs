using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.Image).HasMaxLength(256);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.SeoPageTitle).HasMaxLength(256);

            builder.Property(x => x.SeoAlias).HasMaxLength(256);

            builder.Property(x => x.SeoKeywords).HasMaxLength(256);

            builder.Property(x => x.SeoDescription).HasMaxLength(256);
        }
    }
}
