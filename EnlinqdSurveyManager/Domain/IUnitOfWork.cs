using EnlinqdSurveyManager.Domain.Repositories;

namespace EnlinqdSurveyManager.Domain
{
    public interface IUnitOfWork
    {
        ISurveyRepository surveyRepository { get; }
    }
}
