using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Survey;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class SurveyRepository: ISurveyRepository
    {
        private readonly EnlinqdDBContext _dbContext;
        public SurveyRepository(EnlinqdDBContext enlinqdDBContext) => _dbContext = enlinqdDBContext;

        public async Task<IEnumerable<SurveyDefinition>> GetAllSurveyDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<SurveyDefinition> query = _dbContext.SurveyDefinitions;
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<SurveyDefinition> GetSurveyDefinitionByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var survey = await _dbContext.SurveyDefinitions.FindAsync(id, cancellationToken);
            return survey;
        }
    }
}
