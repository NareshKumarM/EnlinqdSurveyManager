using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models;
using EnlinqdSurveyManager.Domain.Repositories;
using EnlinqdSurveyManager.Infrastructure.Repositories;

namespace EnlinqdSurveyManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyDBContext _dbContext;

        private ISurveyRepository _surveyRepo;
        public UnitOfWork(SurveyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public ISurveyRepository SurveyRepository => this._surveyRepo ?? (this._surveyRepo = new SurveyRepository(_dbContext));

        ISurveyRepository IUnitOfWork.surveyRepository => this._surveyRepo ?? (this._surveyRepo = new SurveyRepository(_dbContext));
    }
}
