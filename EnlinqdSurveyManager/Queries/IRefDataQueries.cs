using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Queries
{
    public interface IRefDataQueries
    {
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
    }
}
