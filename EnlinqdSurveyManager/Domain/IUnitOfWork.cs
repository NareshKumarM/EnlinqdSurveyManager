using EnlinqdSurveyManager.Domain.Repositories;

namespace EnlinqdSurveyManager.Domain
{
    public interface IUnitOfWork
    {
        ISurveyRepository SurveyRepository { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
