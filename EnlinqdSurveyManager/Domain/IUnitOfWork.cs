using EnlinqdSurveyManager.Domain.Repositories;

namespace EnlinqdSurveyManager.Domain
{
    public interface IUnitOfWork
    {
        ISurveyRepository SurveyRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICampaignRepository CampaignRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
