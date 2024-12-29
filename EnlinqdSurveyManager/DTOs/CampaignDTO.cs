using EnlinqdSurveyManager.Domain.Models.Campaign;

namespace EnlinqdSurveyManager.DTOs
{
    public class CampaignDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Products { get; set; }

        public CampaignDTO() { }

        public CampaignDTO(Campaign campaign)
        {
            Name = campaign.Name;
            Description = campaign.Description;
            Products = campaign.Products;
        }
    }
}
