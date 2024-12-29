using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Application.Commands.Orders
{
    public interface IOrderCommandHandler
    {
        Task<string> CreateOrderAsync(RewardRequestDTO rewardRequest, CancellationToken cancellationToken = default);
        Task<string> UpdateOrderAsync(string id, OrderDTO orderRequest, CancellationToken cancellationToken = default);
    }
}
