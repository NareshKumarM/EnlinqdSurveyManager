using EnlinqdSurveyManager.Domain.Models.RefData;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
    }
}
