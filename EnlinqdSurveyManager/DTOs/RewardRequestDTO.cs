using EnlinqdSurveyManager.Domain.Models.Rewarding;

namespace EnlinqdSurveyManager.DTOs
{
    public class RewardRequestDTO
    {
        public Guid Id { get; set; }
        public decimal Denomination { get; set; }
        public string CurrencyCode { get; set; }
        public string DeliveryMethod { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string FundingSourceId { get; set; }
        public string? CampaignId { get; set; }
        public string? ExternalId { get; set; }
        public List<string> Products { get; set; }

        public RewardRequestDTO() { }

        public RewardRequestDTO( Reward reward, string fundingSourceId) {
            Id = reward.Id;
            Denomination = reward.Value.Denomination;
            CurrencyCode = reward.Value.CurrencyCode;
            DeliveryMethod = reward.Delivery.Method;
            RecipientName = reward.Recipient.Name;
            RecipientEmail = reward.Recipient.Email;
            FundingSourceId = fundingSourceId;
            CampaignId = reward.CampaignId;
            ExternalId = reward.ExternalId;
            Products = reward.Products;
        }

    }
}
