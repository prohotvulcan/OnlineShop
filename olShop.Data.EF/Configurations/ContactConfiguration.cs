using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(255).IsRequired(true);

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Phone).HasMaxLength(50);

            builder.Property(x => x.Email).HasMaxLength(250);

            builder.Property(x => x.Website).HasMaxLength(250);

            builder.Property(x => x.Address).HasMaxLength(250);
        }
    }
}
