using EnlinqdSurveyManager.Domain.Models.Order;
using EnlinqdSurveyManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2";

        public OrderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/orders");
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

        [HttpGet("orderbyid")]
        public async Task<IActionResult> GetOrderById(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/orders/{id}");
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] RewardRequestDTO rewardRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/orders");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                Order order = new Order(
                    new Order.PaymentDetails { FundingSourceId = rewardRequest.FundingSourceId },
                    new Order.RewardValue { CurrencyCode = rewardRequest.CurrencyCode, Denomination = rewardRequest.Denomination },
                    new Order.RewardDelivery { Method = rewardRequest.DeliveryMethod },
                    new Order.RewardRecipient { Email = rewardRequest.RecipientEmail, Name = rewardRequest.RecipientName },
                    rewardRequest.Products,
                    rewardRequest.CampaignId,
                    rewardRequest.ExternalId
                );

                string jsonPayload = JsonConvert.SerializeObject(order);
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

        [HttpPost("approveorder/id:string")]
        public async Task<IActionResult> ApproveOrder(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/order_approvals/{id}/approve");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                string jsonPayload = JsonConvert.SerializeObject("");
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint.ToString(), httpContent);
                response.EnsureSuccessStatusCode();

                string result = response.Content.ReadAsStringAsync().Result;

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("rejectorder/id:string")]
        public async Task<IActionResult> RejectOrder(string id, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = new Uri($"{_endpoint}/order_approvals/{id}/reject");
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                string jsonPayload = JsonConvert.SerializeObject("");
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint.ToString(), httpContent);
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
