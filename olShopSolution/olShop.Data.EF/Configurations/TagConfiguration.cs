using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.Type)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}
