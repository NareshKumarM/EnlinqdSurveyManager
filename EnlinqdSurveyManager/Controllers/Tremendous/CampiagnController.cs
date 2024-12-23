using EnlinqdSurveyManager.Domain.Models.Campaign;
using EnlinqdSurveyManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    public class CampaignController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2/campaigns";

        public CampaignController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("campaigns")]
        public async Task<IActionResult> GetCampaigns(CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}");
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

        [HttpGet("campaignbyid")]
        public async Task<IActionResult> GetCampaignById(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/{id}");
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

        [HttpPost("createcampaign")]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignDTO campaignRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                List<string> products = campaignRequest.ProductsCSV.Split(',').ToList();

                Campaign Campaign = new Campaign(campaignRequest.Name, campaignRequest.Description, products);

                string jsonPayload = JsonConvert.SerializeObject(Campaign);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint.ToString(), httpContent);

                string result = response.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("updatecampaign")]
        public async Task<IActionResult> UpdateCampaign(string id, [FromBody] CampaignDTO campaignRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/{id}");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                List<string> products = campaignRequest.ProductsCSV.Split(',').ToList();

                Campaign Campaign = new Campaign(campaignRequest.Name, campaignRequest.Description, products);

                string jsonPayload = JsonConvert.SerializeObject(Campaign);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint.ToString(), httpContent);

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
