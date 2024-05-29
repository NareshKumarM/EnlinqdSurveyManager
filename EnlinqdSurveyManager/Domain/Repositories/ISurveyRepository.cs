using EnlinqdSurveyManager.Domain.Models;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<SurveyDefinition>> GetAllSurveyDefinitionsAsync(CancellationToken cancellationToken = default);
        Task<SurveyDefinition> GetSurveyDefinitionByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
