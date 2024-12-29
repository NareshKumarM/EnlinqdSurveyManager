using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Campaign;
using EnlinqdSurveyManager.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EnlinqdSurveyManager.Application.Commands.Campaigns
{
    public class CampaignCommandHandler : ICampaignCommandHandler
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2/campaigns";
        protected Uri endpoint;
        private readonly IUnitOfWork _unitOfWork;

        public CampaignCommandHandler(HttpClient httpClient, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateCampaignAsync(CampaignDTO campaignRequest, CancellationToken cancellationToken = default)
        {
            string result;

            try
            {
                Campaign campaign = new Campaign(campaignRequest.Name, campaignRequest.Description, campaignRequest.Products);
                string jsonPayload = JsonConvert.SerializeObject(campaign);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://testflight.tremendous.com/api/v2/campaigns"),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "authorization", "Bearer TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB" },
                    },
                    Content = httpContent
                };

                using (var res = await client.SendAsync(request))
                {
                    res.EnsureSuccessStatusCode();
                    result = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }

                //endpoint = new Uri($"{_endpoint}");

                //Campaign campaign = new Campaign(campaignRequest.Name, campaignRequest.Description, campaignRequest.Products);
                //var payload = campaign;

                //string jsonPayload = JsonConvert.SerializeObject(campaign);

                //var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                //var response = await _httpClient.PostAsync(endpoint.ToString(), httpContent);

                //if (!response.IsSuccessStatusCode)
                //{
                //    return string.Empty;
                //}

                //result = response.Content.ReadAsStringAsync().Result;

                //await _unitOfWork.CampaignRepository.AddCampaignAsync(new CampaignDb(campaign.Name, campaign.Description, campaign.Products));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateCampaignAsync(string id, CampaignDTO campaignRequest, CancellationToken cancellationToken = default)
        {
            string result;

            try
            {
                endpoint = new Uri($"{_endpoint}/{id}");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                Campaign Campaign = new Campaign(campaignRequest.Name, campaignRequest.Description, campaignRequest.Products);

                string jsonPayload = JsonConvert.SerializeObject(Campaign);
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint.ToString(), httpContent);

                result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result ?? string.Empty;
        }
    }
}
