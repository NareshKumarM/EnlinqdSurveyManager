using EnlinqdSurveyManager.Domain.Models;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class SurveyRepository: ISurveyRepository
    {
        private readonly SurveyDBContext _dbContext;
        public SurveyRepository(SurveyDBContext surveyDBContext) => _dbContext = surveyDBContext;

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
