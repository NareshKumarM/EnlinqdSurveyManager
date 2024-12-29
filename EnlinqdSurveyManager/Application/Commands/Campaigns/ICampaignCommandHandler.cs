using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Application.Commands.Campaigns
{
    public interface ICampaignCommandHandler
    {
        Task<string> CreateCampaignAsync(CampaignDTO campaign, CancellationToken cancellationToken = default);
        Task<string> UpdateCampaignAsync(string id, CampaignDTO campaignRequest, CancellationToken cancellationToken = default);
    }
}
