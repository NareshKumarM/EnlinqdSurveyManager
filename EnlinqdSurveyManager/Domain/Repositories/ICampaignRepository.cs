using EnlinqdSurveyManager.Domain.Models.Campaign;

namespace EnlinqdSurveyManager.Domain.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> GetAllCampaignsAsync(CancellationToken cancellationToken = default);
        Task<Campaign> GetCampaignByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
