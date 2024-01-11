using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Models
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options) { }

        public DbSet<SurveyDefinition> SurveyDefinitions { get; set; } = null!;
    }
}
