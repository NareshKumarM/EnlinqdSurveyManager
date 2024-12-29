namespace EnlinqdSurveyManager.Domain.Models.Order
{
    public class RewardDb
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Denomination { get; set; }
        public string CurrencyCode { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryStatus { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }

        public RewardDb() { }

        public RewardDb(
            Guid id,
            Guid orderId,
            DateTime createdAt,
            decimal denomination,
            string currencyCode,
            string deliveryMethod,
            string deliveryStatus,
            string recipientEmail,
            string recipientName,
            string recipientPhone
            )
        {
            Id = id;
            OrderId = orderId;
            CreatedAt = createdAt;
            Denomination = denomination;
            CurrencyCode = currencyCode;
            DeliveryMethod = deliveryMethod;
            DeliveryStatus = deliveryStatus;
            RecipientEmail = recipientEmail;
            RecipientName = recipientName ;
            RecipientPhone = recipientPhone;
        }
    }
}
