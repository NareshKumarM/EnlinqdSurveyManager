using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Order;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EnlinqdDBContext _dbContext;
        public OrderRepository(EnlinqdDBContext enlinqdDBContext) => _dbContext = enlinqdDBContext;

        public async Task<IEnumerable<OrderDb>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<OrderDb> query = _dbContext.Orders;
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<OrderDb> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _dbContext.Orders.FindAsync(id, cancellationToken);
            return order;
        }
    }
}
