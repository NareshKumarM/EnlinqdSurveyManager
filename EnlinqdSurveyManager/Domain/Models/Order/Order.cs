using System.Text.Json.Serialization;

namespace EnlinqdSurveyManager.Domain.Models.Order
{
    public class Order
    {

        [JsonPropertyName("external_id")]
        public string? ExternalId { get; set; }

        [JsonPropertyName("campaign_id")]
        public string? CampaignId { get; set; }

        [JsonPropertyName("payment")]
        public PaymentDetails Payment { get; set; }

        [JsonPropertyName("reward")]
        public RewardDetails Reward { get; set; }

        public class PaymentDetails
        {
            [JsonPropertyName("funding_source_id")]
            public string FundingSourceId { get; set; } = "BALANCE";
        }

        public class RewardDetails
        {
            [JsonPropertyName("value")]
            public RewardValue Value { get; set; }

            [JsonPropertyName("delivery")]
            public RewardDelivery Delivery { get; set; }

            [JsonPropertyName("recipient")]
            public RewardRecipient Recipient { get; set; }

            [JsonPropertyName("products")]
            public List<string> Products { get; set; }
        }

        public class RewardValue
        {
            [JsonPropertyName("denomination")]
            public decimal Denomination { get; set; }
            [JsonPropertyName("currency_code")]
            public string CurrencyCode { get; set; }
        }

        public class RewardDelivery
        {
            [JsonPropertyName("method")]
            public string Method { get; set; }
        }

        public class RewardRecipient
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }
        }

        public Order() { }

        public Order(PaymentDetails paymentDetails, RewardValue rewardValue, RewardDelivery rewardDelivery, RewardRecipient rewardRecipient, List<string> products, string? campaignId = null, string? externalId = null) {
            this.ExternalId = externalId;
            this.CampaignId = campaignId;
            this.Payment = paymentDetails;
            this.Reward = new RewardDetails
            {
                Value = rewardValue,
                Delivery = rewardDelivery,
                Recipient = rewardRecipient,
                Products = products
            };
        }
    }
}
