using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class AdvertistmentPageConfiguration : IEntityTypeConfiguration<AdvertistmentPage>
    {
        public void Configure(EntityTypeBuilder<AdvertistmentPage> builder)
        {
            builder.ToTable("AdvertistmentPages");

            builder.HasKey(x => x.Id);
        }
    }
}
