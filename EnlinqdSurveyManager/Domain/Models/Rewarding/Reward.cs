namespace EnlinqdSurveyManager.Domain.Models.Rewarding
{

    public class RewardValue
    {
        public decimal Denomination { get; set; }
        public string CurrencyCode { get; set; }

        public RewardValue(decimal denomination, string currencyCode)
        {
            Denomination = denomination;
            CurrencyCode = currencyCode;
        }
    }

    public class RewardDelivery
    {
        public string Method { get; set; }
        public RewardDelivery(string method)
        {
            Method = method;
        }
    }

    public class RewardRecipient
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public RewardRecipient(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class RewardPayment
    {
        public string FundingSourceId { get; set; }

        public RewardPayment(string fundingSourceId)
        {
            FundingSourceId = fundingSourceId;
        }
    }

    public class Reward
    {
        public Guid Id { get; set; }
        public string? CampaignId { get; set; }
        public string? ExternalId { get; set; }
        public RewardValue Value { get; set; }
        public RewardDelivery Delivery { get; set; }
        public RewardRecipient Recipient { get; set; }
        public List<string> Products { get; set; }

        public Reward() { }

        public Reward(Guid id, decimal denomination, string currencyCode, string deliveryMethod, string recipientName, string recipientEmail, List<string> products, string? campaignId, string? externalId)
        {
            Id = id;
            Value = new RewardValue(denomination, currencyCode);
            Delivery = new RewardDelivery(deliveryMethod);
            Recipient = new RewardRecipient(recipientName, recipientEmail);
            Products = products;
            CampaignId = campaignId;
            ExternalId = externalId;
        }
    }

    public class RewardRequest
    {
        public RewardPayment Payment { get; set; }
        public Reward Reward { get; set; }

        public RewardRequest() { }

        public RewardRequest(RewardPayment payment, Reward reward)
        {
            Payment = payment;
            Reward = reward;
        }
    }
}
