using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Domain.Models
{
    public class SurveyDBContext : DbContext
    {
        public SurveyDBContext(DbContextOptions<SurveyDBContext> options) : base(options) { }

        public DbSet<SurveyDefinition> SurveyDefinitions { get; set; } = null!;
    }
}
