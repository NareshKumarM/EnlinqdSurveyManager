using EnlinqdSurveyManager.Domain.Models.Campaign;
using EnlinqdSurveyManager.Domain.Models.Order;
using EnlinqdSurveyManager.Domain.Models.Payouts;
using EnlinqdSurveyManager.Domain.Models.RefData;
using EnlinqdSurveyManager.Domain.Models.Survey;
using EnlinqdSurveyManager.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Domain
{
    public class EnlinqdDBContext : DbContext
    {
        public EnlinqdDBContext(DbContextOptions<EnlinqdDBContext> options) : base(options) { }

        public DbSet<SurveyDefinition> SurveyDefinitions { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<PayoutSummaryBatch> PayoutSummaryBatches { get; set; } = null!;
        public DbSet<CampaignDb> Campaigns { get; set; } = null!;
        public DbSet<OrderDb> Orders { get; set; } = null!;
        public DbSet<RewardDb> Rewards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyDefinition>();
            modelBuilder.Entity<Country>();
            modelBuilder.Entity<CampaignDb>();
            modelBuilder.Entity<PayoutSummaryBatch>();
            modelBuilder.Entity<OrderDb>();
            modelBuilder.Entity<RewardDb>();

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new RewardConfiguration());
            modelBuilder.ApplyConfiguration(new CampaignConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
