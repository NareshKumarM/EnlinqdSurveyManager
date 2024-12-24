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
        public async Task<IEnumerable<Campaign>> GetAllCampaignsAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<Campaign> query = _dbContext.Campaigns;
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Campaign> GetCampaignByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var campaign = await _dbContext.Campaigns.FindAsync(id, cancellationToken);
            return campaign;
        }
    }
}
