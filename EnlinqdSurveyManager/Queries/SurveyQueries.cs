using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.Survey;
using EnlinqdSurveyManager.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace EnlinqdSurveyManager.Queries
{
    public class SurveyQueries: ISurveyQueries
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        public SurveyQueries(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        #region Public Methods

        public async Task<SurveyDefinitionDTO> GetSurveyDefinitionByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ValidationException("Please supply a valid SurveyDefinition ID");

            SurveyDefinition survey = await _unitOfWork.SurveyRepository.GetSurveyDefinitionByIdAsync(id, cancellationToken);

            if (survey == null)
            {
                return null;
            }

            SurveyDefinitionDTO alarmDTO = new SurveyDefinitionDTO(survey);

            return alarmDTO;
        }

        public async Task<IEnumerable<SurveyDefinitionDTO>> GetAllSurveyDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            List<SurveyDefinition>? surveys = (await _unitOfWork.SurveyRepository.GetAllSurveyDefinitionsAsync(cancellationToken))?.ToList();

            if (surveys == null || !surveys.Any())
                return null;

            List<SurveyDefinitionDTO> surveyDTOs = new List<SurveyDefinitionDTO>();

            foreach (SurveyDefinition survey in surveys)
            {
                surveyDTOs.Add(new SurveyDefinitionDTO(survey));
            }

            return surveyDTOs;
        }

        #endregion
    }
}
