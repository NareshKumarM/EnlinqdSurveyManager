using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.RefData;
using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Queries
{
    public class RefDataQueries : IRefDataQueries
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion
        public RefDataQueries(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            List<Country>? countries = (await _unitOfWork.CountryRepository.GetAllCountriesAsync(cancellationToken))?.ToList();

            if (countries == null || !countries.Any())
                return null;

            List<CountryDTO> countryDTOs = countries.Select(a => new CountryDTO(a)).ToList();

            return countryDTOs;
        }
    }
}
