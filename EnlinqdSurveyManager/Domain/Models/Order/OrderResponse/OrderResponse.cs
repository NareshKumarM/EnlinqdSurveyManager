using Newtonsoft.Json;

namespace EnlinqdSurveyManager.Domain.Models.Order.OrderResponse
{
    public class OrderResponse
    {
        [JsonProperty("order")]
        public Orders Order { get; set; }
    }

    public class Orders
    {
        [JsonProperty("id")]
        public string OrderId { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("payment")]
        public PaymentResponse Payment { get; set; }

        [JsonProperty("rewards")]
        public List<RewardResponse> Rewards { get; set; }
    }

    public class PaymentResponse
    {
        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("fees")]
        public decimal Fees { get; set; }

        [JsonProperty("discount")]
        public decimal Discount { get; set; }
    }

    public class RewardResponse
    {
        [JsonProperty("id")]
        public string RewardId { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("value")]
        public RewardValue Value { get; set; }

        [JsonProperty("delivery")]
        public DeliveryResponse Delivery { get; set; }

        [JsonProperty("recipient")]
        public RecipientResponse Recipient { get; set; }
    }

    public class RewardValue
    {
        [JsonProperty("denomination")]
        public decimal Denomination { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class DeliveryResponse
    {
        [JsonProperty("method")]
        public string DeliveryMethod { get; set; }

        [JsonProperty("status")]
        public string DeliveryStatus { get; set; }
    }

    public class RecipientResponse
    {
        [JsonProperty("email")]
        public string RecipientEmail { get; set; }

        [JsonProperty("name")]
        public string RecipientName { get; set; }

        [JsonProperty("phone")]
        public string RecipientPhone { get; set; }
    }
}
