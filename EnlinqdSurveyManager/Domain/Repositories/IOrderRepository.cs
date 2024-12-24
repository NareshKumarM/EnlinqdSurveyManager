using EnlinqdSurveyManager.Domain.Models.Order;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDb>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
        Task<OrderDb> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
