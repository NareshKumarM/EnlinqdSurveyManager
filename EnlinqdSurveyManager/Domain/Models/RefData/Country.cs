namespace EnlinqdSurveyManager.Domain.Models.RefData
{
    public class Country
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
    }
}
