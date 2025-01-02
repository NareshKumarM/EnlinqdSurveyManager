using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.DTOs;
using EnlinqdSurveyManager.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefDataController : ControllerBase
    {
        #region Private Fields

        private readonly IRefDataQueries _refDataQueries;

        #endregion

        public RefDataController(IRefDataQueries refDataQueries)
        {
            this._refDataQueries = refDataQueries;
        }


        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken = default)
        {
            List<CountryDTO> countries = (await _refDataQueries.GetAllCountriesAsync(cancellationToken)).ToList();

            return Ok(countries);

        }
    }
}