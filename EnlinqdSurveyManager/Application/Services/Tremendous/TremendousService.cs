using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace EnlinqdSurveyManager.Application.Services.Tremendous
{
   

    public class TremendousService : ITremendousService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSetting _appSettings;
        protected string _endPoint;
        protected string _token;

        public TremendousService(HttpClient httpClient, IOptions<AppSetting> options)
        {
            _httpClient = httpClient;
            _appSettings = options.Value;

            _endPoint = _appSettings.api;
            _token = _appSettings.token;

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<string> GetProducts(string country, string currency, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_endPoint}/v2/products?country=US&currency=USD");
            var result = await _httpClient.GetAsync(uri,cancellationToken);
            return await result.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
