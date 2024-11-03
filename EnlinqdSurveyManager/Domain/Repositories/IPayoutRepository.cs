using EnlinqdSurveyManager.Domain.Models.Payouts;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface IPayoutRepository
    {
        Task<IEnumerable<PayoutSummaryBatch>> GetAllPayoutSummaryBatchsAsync(CancellationToken cancellationToken = default);
        Task<PayoutSummaryBatch> GetPayoutSummaryBatchByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
