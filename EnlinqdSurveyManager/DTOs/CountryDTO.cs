using EnlinqdSurveyManager.Domain.Models.RefData;
using EnlinqdSurveyManager.Domain.Models.Survey;

namespace EnlinqdSurveyManager.DTOs
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }

        public CountryDTO() { }

        public CountryDTO(Country country)
        {
            Id = country.Id;
            CountryCode = country.CountryCode;
            CountryName = country.CountryName;
            CurrencyCode = country.CurrencyCode;
        }
    }
}
