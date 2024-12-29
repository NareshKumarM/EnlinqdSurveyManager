using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Order;
using EnlinqdSurveyManager.Domain.Models.Order.OrderResponse;
using EnlinqdSurveyManager.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EnlinqdSurveyManager.Application.Commands.Orders
{
    public class OrderCommandHandler : IOrderCommandHandler
    {
        private readonly HttpClient _httpClient;
        protected static readonly string _token = "TEST_viNlCbjK8--BjNJcB4lgM8FKHrY03K3nGa5uaNOliCB";
        protected static readonly string _endpoint = "https://testflight.tremendous.com/api/v2/orders";
        protected Uri endpoint;
        private readonly IUnitOfWork _unitOfWork;

        public OrderCommandHandler(HttpClient httpClient, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateOrderAsync(RewardRequestDTO rewardRequest, CancellationToken cancellationToken = default)
        {
            string result = string.Empty;

            try
            {
                endpoint = new Uri($"{_endpoint}");

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

                if (response != null)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    if (result == null)
                    {
                        return string.Empty;
                    }

                    OrderResponse resp = JsonConvert.DeserializeObject<OrderResponse>(result);

                    await _unitOfWork.OrderRepository.AddNewOrderAsync(
                        new OrderDb(
                            rewardRequest.Id,
                            resp.Order.OrderId,
                            resp.Order.ExternalId,
                            resp.Order.CampaignId, 
                            resp.Order.CreatedAt, 
                            resp.Order.Channel, 
                            resp.Order.Status, 
                            resp.Order.Payment.Subtotal, 
                            resp.Order.Payment.Total, 
                            resp.Order.Payment.Fees, 
                            resp.Order.Payment.Discount,
                            resp.Order.Rewards.Select(a => 
                                new RewardDb(
                                    Guid.NewGuid(),
                                    rewardRequest.Id,
                                    a.CreatedAt, 
                                    a.Value.Denomination, 
                                    a.Value.CurrencyCode, 
                                    a.Delivery.DeliveryMethod, 
                                    a.Delivery.DeliveryStatus, 
                                    a.Recipient.RecipientEmail, 
                                    a.Recipient.RecipientName, 
                                    a.Recipient.RecipientPhone
                                )
                            ).ToList())
                        );

                    await _unitOfWork.SaveChangesAsync(cancellationToken);

                    return result;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> UpdateOrderAsync(string id, OrderDTO orderRequest, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
