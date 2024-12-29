using EnlinqdSurveyManager.Domain.Models.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.EntityTypeConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderDb>
    {
        public void Configure(EntityTypeBuilder<OrderDb> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderId).IsRequired();
            builder.HasMany(o => o.Rewards).WithOne().HasForeignKey(r => r.OrderId);
        }
    }
}
