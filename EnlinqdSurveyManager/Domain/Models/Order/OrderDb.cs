namespace EnlinqdSurveyManager.Domain.Models.Order
{
    public partial class OrderDb
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public string ExternalId { get; set; }
        public string CampaignId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Channel { get; set; }
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Fees { get; set; }
        public decimal Discount { get; set; }
        public List<RewardDb> Rewards { get; set; }

        public OrderDb() { }

        public OrderDb(
            Guid id,
            string orderId,
            string externalId,
            string campaignId,
            DateTime createdAt,
            string channel,
            string status,
            decimal subtotal,
            decimal total,
            decimal fees,
            decimal discount,
            List<RewardDb> rewards)
        {
            Id = id;
            OrderId = orderId;
            ExternalId = externalId;
            CreatedAt = createdAt;
            Channel = channel;
            Status = status;
            Subtotal = subtotal;
            Total = total;
            Fees = fees;
            Discount = discount;
            Rewards = rewards;
        }
    }
}
