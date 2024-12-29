using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Queries
{
    public interface ISurveyQueries
    {
        Task<IEnumerable<SurveyDefinitionDTO>> GetAllSurveyDefinitionsAsync(CancellationToken cancellationToken = default);
        Task<SurveyDefinitionDTO> GetSurveyDefinitionByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
