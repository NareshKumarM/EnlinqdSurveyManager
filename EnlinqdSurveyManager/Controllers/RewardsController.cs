using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace EnlinqdSurveyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        public RewardsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(string country, string currency, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"https://testflight.tremendous.com/api/v2/products?country={country}&currency={currency}");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                //HttpResponseMessage response = await _httpClient.GetAsync(parameters).ConfigureAwait(false);
                var response = _httpClient.GetAsync(endpoint,cancellationToken).Result;
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
