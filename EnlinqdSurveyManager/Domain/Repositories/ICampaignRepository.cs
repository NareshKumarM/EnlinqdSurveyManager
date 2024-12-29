using EnlinqdSurveyManager.Domain.Models.Campaign;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<CampaignDb>> GetAllCampaignsAsync(CancellationToken cancellationToken = default);
        Task<CampaignDb> GetCampaignByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CampaignDb> AddCampaignAsync(CampaignDb campaign, CancellationToken cancellationToken = default);
    }
}
