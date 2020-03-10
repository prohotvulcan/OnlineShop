using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using olShop.Data.Entities;

namespace olShop.Data.EF.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Email).HasMaxLength(250);

            builder.Property(x => x.Message).HasMaxLength(500);
        }
    }
}
