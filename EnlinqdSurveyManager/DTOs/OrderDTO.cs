namespace EnlinqdSurveyManager.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string ExternalId { get; set; }
        public string CampaignId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Channel { get; set; }
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Fees { get; set; }
        public decimal Discount { get; set; }
        public List<RewardDTO> Rewards { get; set; }
    }
}
