using EnlinqdSurveyManager.Domain.Models;
using EnlinqdSurveyManager.DTOs;

namespace EnlinqdSurveyManager.Application.Commands
{
    public interface IUpdateSurveyCommandHandler
    {
        Task<SurveyDefinitionDTO> UpdateSurveyAsync(Guid id, List<PatchCommand> patchCommands, CancellationToken cancellationToken = default);
    }
}
