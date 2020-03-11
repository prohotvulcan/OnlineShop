using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;
using olShop.Data.Enums;

namespace olShop.Data.EF.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(20)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(x => x.CustomerName)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.CustomerAddress)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.CustomerMobile)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.CustomerMessage)
                .HasMaxLength(256)
                .IsRequired(true);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.User)
                .WithMany(y => y.Bills)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
