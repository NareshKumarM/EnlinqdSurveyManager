using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models;
using EnlinqdSurveyManager.DTOs;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace EnlinqdSurveyManager.Application.Commands
{
    public partial class UpdateSurveyCommandHandler : IUpdateSurveyCommandHandler
    {

        #region Private Fields

        //private readonly IAlarmValidator _alarmValidator;
        //private readonly ILocalizationService _localizationService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public UpdateSurveyCommandHandler(/*IAlarmValidator alarmValidator,
                                        ILocalizationService localizationService,*/
                                        IUnitOfWork unitOfWork)
        {
            //_alarmValidator = alarmValidator;
            //_localizationService = localizationService;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public async Task<SurveyDefinitionDTO> UpdateSurveyAsync(Guid id, List<PatchCommand> patchCommands, CancellationToken cancellationToken)
        {

            if (id == Guid.Empty)
                throw new ValidationException("Please supply a valid Alarm ID");

            if (patchCommands == null || !patchCommands.Any())
                throw new ValidationException("Patch commands cannot be empty. Please supply a valid list of patch commands.");

            SurveyDefinition survey = await _unitOfWork.SurveyRepository.GetSurveyDefinitionByIdAsync(id, cancellationToken);

            if(survey == null)
            {
                throw new ValidationException("Survey not available");
            }


            List<PatchCommand> surveyPatchCommands = new List<PatchCommand>();
            foreach (PatchCommand patchCommand in patchCommands)
            {
                switch (patchCommand.Command)
                {
                    case "UpdateTitle":
                    case "UpdateSurvey":
                        surveyPatchCommands.Add(patchCommand);
                        break;
                }
            }

            if (surveyPatchCommands.Any())
                await ApplySurveyPatchCommandsAsync(survey, surveyPatchCommands, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SurveyDefinitionDTO(survey);
        }

        #endregion

        #region Private Methods

        private async Task ApplySurveyPatchCommandsAsync(SurveyDefinition survey, List<PatchCommand> patchCommands, CancellationToken cancellationToken)
        {
            List<PatchCommand> patchCommandsToExecute = patchCommands.Where(p => p.Command == "ChangeAlarmActiveDates").ToList();
            if (patchCommandsToExecute.Any())
                await UpdateTitle(survey, patchCommandsToExecute, cancellationToken);

            patchCommandsToExecute = patchCommands.Where(p => p.Command == "ChangeAlarmMeterType").ToList();
            if (patchCommandsToExecute.Any())
                await UpdateSurvey(survey, patchCommandsToExecute, cancellationToken);

        }

        private async Task UpdateTitle(SurveyDefinition survey, List<PatchCommand> patchCommandsToExecute, CancellationToken cancellationToken)
        {
            foreach (PatchCommand patchCommand in patchCommandsToExecute)
            {
                if (!string.Equals(survey?.Name, patchCommand.Value, StringComparison.OrdinalIgnoreCase))
                {
                    survey.Name = patchCommand.Value;
                }
            }
        }

        private async Task UpdateSurvey(SurveyDefinition survey, List<PatchCommand> patchCommandsToExecute, CancellationToken cancellationToken)
        {
            foreach (PatchCommand patchCommand in patchCommandsToExecute)
            {
                if (!string.Equals(survey?.Json,patchCommand.Value,StringComparison.OrdinalIgnoreCase))
                {
                    survey.Json = patchCommand.Value;
                }
            }
        }

        #endregion
    }
}
