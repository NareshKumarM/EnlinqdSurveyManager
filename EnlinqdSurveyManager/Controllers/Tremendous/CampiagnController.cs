using EnlinqdSurveyManager.Application.Commands.Campaigns;
using EnlinqdSurveyManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    public class CampaignController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2/campaigns";
        private readonly ICampaignCommandHandler _campaignCommandHandler;

        public CampaignController(HttpClient httpClient,
            ICampaignCommandHandler campaignCommandHandler)
        {
            _httpClient = httpClient;
            _campaignCommandHandler = campaignCommandHandler;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        [HttpGet("campaigns")]
        public async Task<IActionResult> GetCampaigns(CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}");
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
                string result = await _campaignCommandHandler.CreateCampaignAsync(campaignRequest, cancellationToken);
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
                string result = await _campaignCommandHandler.UpdateCampaignAsync(id, campaignRequest, cancellationToken);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
