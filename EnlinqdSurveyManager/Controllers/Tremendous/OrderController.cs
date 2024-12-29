using EnlinqdSurveyManager.Application.Commands.Orders;
using EnlinqdSurveyManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EnlinqdSurveyManager.Controllers.Tremendous
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2";
        private readonly IOrderCommandHandler _orderCommandHandler;

        public OrderController(HttpClient httpClient, IOrderCommandHandler orderCommandHandler)
        {
            _httpClient = httpClient;
            _orderCommandHandler = orderCommandHandler;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] RewardRequestDTO rewardRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                try
                {
                    string result = await _orderCommandHandler.CreateOrderAsync(rewardRequest, cancellationToken);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
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
