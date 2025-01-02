using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Campaign;
using EnlinqdSurveyManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlinqdSurveyManager.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly EnlinqdDBContext _dbContext;
        public CampaignRepository(EnlinqdDBContext enlinqdDBContext) => _dbContext = enlinqdDBContext;
        public async Task<IEnumerable<CampaignDb>> GetAllCampaignsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<CampaignDb> query = _dbContext.Campaigns;
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<CampaignDb> GetCampaignByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var campaign = await _dbContext.Campaigns.FindAsync(id, cancellationToken);
            return campaign;
        }

        public async Task<CampaignDb> AddCampaignAsync(CampaignDb campaign, CancellationToken cancellationToken = default)
        {
            await _dbContext.Campaigns.AddAsync(campaign, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return campaign;
        }
    }
}
