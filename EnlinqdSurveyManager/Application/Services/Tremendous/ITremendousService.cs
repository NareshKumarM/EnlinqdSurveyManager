namespace EnlinqdSurveyManager.Application.Services.Tremendous
{
    public interface ITremendousService
    {
        Task<string> GetProducts(string country, string currency, CancellationToken cancellationToken);
    }
}
