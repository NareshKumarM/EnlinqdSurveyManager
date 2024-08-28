using EnlinqdSurveyManager.Domain.Models.Survey;

namespace EnlinqdSurveyManager.Domain.Models.Payouts
{
    public class PayoutSummaryBatch
    {
        public Guid Id { get; set; }
        public string SummaryBatchId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public PayoutSummaryBatch() { }

        public PayoutSummaryBatch(Guid id, string summaryBatchId, DateTimeOffset createdAt)
        {
            SetId(id);
            SetSummaryBatchId(summaryBatchId);
            SetCreatedAt(createdAt);
        }

        private PayoutSummaryBatch SetId(Guid id)
        {
            if (id == Guid.Empty || id == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                Id = Guid.NewGuid();
            }
            else
            {
                Id = id;
            }

            return this;
        }

        private PayoutSummaryBatch SetSummaryBatchId(string summaryBatchId)
        {
            SummaryBatchId = summaryBatchId;
            return this;
        }

        private PayoutSummaryBatch SetCreatedAt(DateTimeOffset createdAt)
        {
            CreatedAt = createdAt;
            return this;
        }
    }
}
