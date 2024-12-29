using Newtonsoft.Json;

namespace EnlinqdSurveyManager.Domain.Models.Order
{
    public class Order
    {

        [JsonProperty("external_id")]
        public string? ExternalId { get; set; }

        [JsonProperty("campaign_id")]
        public string? CampaignId { get; set; }

        [JsonProperty("payment")]
        public PaymentDetails Payment { get; set; }

        [JsonProperty("reward")]
        public RewardDetails Reward { get; set; }

        public class PaymentDetails
        {
            [JsonProperty("funding_source_id")]
            public string FundingSourceId { get; set; } = "BALANCE";
        }

        public class RewardDetails
        {
            [JsonProperty("value")]
            public RewardValue Value { get; set; }

            [JsonProperty("delivery")]
            public RewardDelivery Delivery { get; set; }

            [JsonProperty("recipient")]
            public RewardRecipient Recipient { get; set; }

            [JsonProperty("products")]
            public List<string> Products { get; set; }
        }

        public class RewardValue
        {
            [JsonProperty("denomination")]
            public decimal Denomination { get; set; }
            [JsonProperty("currency_code")]
            public string CurrencyCode { get; set; }
        }

        public class RewardDelivery
        {
            [JsonProperty("method")]
            public string Method { get; set; }
        }

        public class RewardRecipient
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
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
