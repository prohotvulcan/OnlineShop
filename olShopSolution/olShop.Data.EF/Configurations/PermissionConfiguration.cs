using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasMaxLength(20)
                 .IsRequired(true)
                 .UseIdentityColumn();

            builder.Property(x => x.FunctionId)
                .HasMaxLength(128)
                .IsRequired(true);

            builder.HasOne(x => x.AppRole)
                .WithMany(y => y.Permissions)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Function)
                .WithMany(y => y.Permissions)
                .HasForeignKey(x => x.FunctionId);
        }
    }
}
