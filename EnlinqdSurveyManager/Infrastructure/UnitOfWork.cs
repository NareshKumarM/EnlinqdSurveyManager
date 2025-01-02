using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Repositories;
using EnlinqdSurveyManager.Infrastructure.Repositories;

namespace EnlinqdSurveyManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnlinqdDBContext _dbContext;

        private ISurveyRepository _surveyRepo;
        private ICountryRepository _countryRepo;
        private ICampaignRepository _campaignRepo;
        private IOrderRepository _orderRepo;

        public UnitOfWork(EnlinqdDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ISurveyRepository SurveyRepository => this._surveyRepo ?? (this._surveyRepo = new SurveyRepository(_dbContext));

        public ICountryRepository CountryRepository => this._countryRepo ?? (this._countryRepo = new CountryRepository(_dbContext));

        public ICampaignRepository CampaignRepository => this._campaignRepo ?? (this._campaignRepo = new CampaignRepository(_dbContext));

        public IOrderRepository OrderRepository => this._orderRepo ?? (this._orderRepo = new OrderRepository(_dbContext));

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await TrySaveChangesAsync(cancellationToken);
        }

        private async Task TrySaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
