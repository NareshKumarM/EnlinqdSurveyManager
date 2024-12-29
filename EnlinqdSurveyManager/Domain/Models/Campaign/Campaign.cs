using System.Text.Json.Serialization;

namespace EnlinqdSurveyManager.Domain.Models.Campaign
{
    public class Campaign
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("products")]
        public List<string> Products{ get; set; }
        
        public Campaign() { }

        public Campaign(string name, string descritpion, List<string> products ) {
            Id = Guid.NewGuid();
            Name = name;
            Description = descritpion;
            Products = products;
        }
    }
}
