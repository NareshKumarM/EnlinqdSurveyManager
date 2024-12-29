namespace EnlinqdSurveyManager.DTOs
{
    public class RewardDTO
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Denomination { get; set; }
        public string CurrencyCode { get; set; }
        public string DeliveryMethod { get; set; }
        public string DeliveryStatus { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string RecipientPhone { get; set; }
    }
}
