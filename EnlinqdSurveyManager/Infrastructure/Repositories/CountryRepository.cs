using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.RefData;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly EnlinqdDBContext _dbContext;
        public CountryRepository(EnlinqdDBContext enlinqdDBContext) => _dbContext = enlinqdDBContext;

        public async Task<IEnumerable<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Country> query = _dbContext.Countries;
            return await query.ToListAsync(cancellationToken);
        }
    }
}
