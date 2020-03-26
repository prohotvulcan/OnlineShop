using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class FooterConfiguration : IEntityTypeConfiguration<Footer>
    {
        public void Configure(EntityTypeBuilder<Footer> builder)
        {
            builder.ToTable("Footers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired(true);

            builder.Property(x => x.Content).IsRequired(true);
        }
    }
}
