using EnlinqdSurveyManager.Domain.Models.Campaign;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.EntityTypeConfiguration
{
    public class CampaignConfiguration : IEntityTypeConfiguration<CampaignDb>
    {
        public void Configure(EntityTypeBuilder<CampaignDb> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Products).HasConversion(
                v => string.Join(",", v),
                v => new List<string>(v.Split(",", StringSplitOptions.RemoveEmptyEntries))
            );
        }
    }
}
