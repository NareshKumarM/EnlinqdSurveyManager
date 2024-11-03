using EnlinqdSurveyManager.Domain.Models.Payouts;

namespace EnlinqdSurveyManager.DTOs
{
    public class PayoutSummaryBatchDTO
    {
        public Guid Id { get; set; }
        public string SummaryBatchId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public PayoutSummaryBatchDTO() { }

        public PayoutSummaryBatchDTO(PayoutSummaryBatch payoutSummaryBatch)
        {
            Id = payoutSummaryBatch.Id;
            CreatedAt = payoutSummaryBatch.CreatedAt;
            SummaryBatchId = payoutSummaryBatch.SummaryBatchId;
        }
    }
}
