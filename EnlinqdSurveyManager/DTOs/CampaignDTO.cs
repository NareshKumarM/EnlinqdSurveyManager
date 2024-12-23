using EnlinqdSurveyManager.Domain.Models.Campaign;

namespace EnlinqdSurveyManager.DTOs
{
    public class CampaignDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductsCSV { get; set; }

        public CampaignDTO() { }

        public CampaignDTO(Campaign campaign)
        {
            Id = campaign.Id;
            Name = campaign.Name;
            Description = campaign.Description;
            ProductsCSV = campaign.Products.Any() ? String.Join(",", campaign.Products) : string.Empty;
        }
    }
}
