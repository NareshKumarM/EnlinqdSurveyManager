using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Repositories;
using EnlinqdSurveyManager.Infrastructure.Repositories;

namespace EnlinqdSurveyManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnlinqdDBContext _dbContext;

        private ISurveyRepository _surveyRepo;

        public UnitOfWork(EnlinqdDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ISurveyRepository SurveyRepository => this._surveyRepo ?? (this._surveyRepo = new SurveyRepository(_dbContext));

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
                //LoggerExtensions.LogError(eventId: new EventId(-1, "UnitOfWork TrySaveChangesAsync Failed"), logger: _logger, exception: ex, message: "[ERROR] - UnitOfWork TrySaveChangesAsync Failed. Message: [" + ex.GetBaseException().Message + "].", args: Array.Empty<object>());
            }
        }
    }
}
