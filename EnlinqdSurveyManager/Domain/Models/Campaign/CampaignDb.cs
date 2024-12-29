using System.Text.Json.Serialization;

namespace EnlinqdSurveyManager.Domain.Models.Campaign
{
    public class CampaignDb
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Products { get; set; }

        public CampaignDb() { }

        public CampaignDb(string name, string descritpion, List<string> products)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = descritpion;
            Products = products;
        }
    }
}
