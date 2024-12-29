using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Payouts;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class PayoutRepository: IPayoutRepository
    {
        private readonly EnlinqdDBContext _dbContext;
        public PayoutRepository(EnlinqdDBContext enlinqdDBContext) => _dbContext = enlinqdDBContext;

        public async Task<IEnumerable<PayoutSummaryBatch>> GetAllPayoutSummaryBatchsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<PayoutSummaryBatch> query = _dbContext.PayoutSummaryBatches;
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<PayoutSummaryBatch> GetPayoutSummaryBatchByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var payoutSummaryBatch = await _dbContext.PayoutSummaryBatches.FindAsync(id, cancellationToken);
            return payoutSummaryBatch;
        }

    }
}
