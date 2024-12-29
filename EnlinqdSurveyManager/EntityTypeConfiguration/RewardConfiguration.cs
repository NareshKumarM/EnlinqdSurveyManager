using EnlinqdSurveyManager.Domain.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnlinqdSurveyManager.EntityTypeConfiguration
{
    public class RewardConfiguration : IEntityTypeConfiguration<RewardDb>
    {
        public void Configure(EntityTypeBuilder<RewardDb> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.CreatedAt).IsRequired();
            builder.Property(r => r.Denomination).IsRequired();
            builder.Property(r => r.CurrencyCode).IsRequired();
            builder.Property(r => r.RecipientEmail).IsRequired();

            // Configure foreign key relationship
            builder.HasOne<OrderDb>()
                .WithMany(o => o.Rewards)
                .HasForeignKey(r => r.OrderId)
                .IsRequired();
        }
    }
}
