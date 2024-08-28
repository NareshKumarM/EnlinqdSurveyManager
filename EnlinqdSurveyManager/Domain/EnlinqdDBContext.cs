using EnlinqdSurveyManager.Domain.Models.Payouts;
using EnlinqdSurveyManager.Domain.Models.Survey;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Domain
{
    public class EnlinqdDBContext : DbContext
    {
        public EnlinqdDBContext(DbContextOptions<EnlinqdDBContext> options) : base(options) { }

        public DbSet<SurveyDefinition> SurveyDefinitions { get; set; } = null!;
        public DbSet<PayoutSummaryBatch> PayoutSummaryBatches { get; set; } = null!;
    }
}
