using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2";

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(string country, string currency, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/products?country={country}&currency={currency}");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var response = _httpClient.GetAsync(endpoint, cancellationToken).Result;
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
