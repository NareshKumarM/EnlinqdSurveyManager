using EnlinqdSurveyManager.Application.Commands.Survey;
using EnlinqdSurveyManager.Domain;
using EnlinqdSurveyManager.Domain.Models.PatchCommand;
using EnlinqdSurveyManager.Domain.Models.Survey;
using EnlinqdSurveyManager.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnlinqdSurveyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        #region Private Fields

        //private readonly ISurveyQueries _surveyQueries;
        private readonly EnlinqdDBContext enlinqdDBContext;
        private readonly IUpdateSurveyCommandHandler _updateSurveyCommandHandler;

        #endregion Private Fields

        //public SurveysController(SurveyDBContext dbContext, SurveyQueries surveyQueries)
        public SurveysController(EnlinqdDBContext dbContext,
            IUpdateSurveyCommandHandler updateSurveyCommandHandler)
        {
            this.enlinqdDBContext = dbContext;
            _updateSurveyCommandHandler = updateSurveyCommandHandler;
            //_surveyQueries = surveyQueries;
        }

        // GET: api/<SurveysController>
        [HttpGet("summary")]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await enlinqdDBContext.SurveyDefinitions.ToListAsync());
        }

        // GET api/<SurveysController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var survey = await enlinqdDBContext.SurveyDefinitions.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        // POST api/<SurveysController>
        [HttpPost]
        public async Task<IActionResult> AddSurvey([FromBody] SurveyDefinitionDTO surveyDefinitionDTO, CancellationToken cancellationToken = default)
        {
            SurveyDefinition survey = new SurveyDefinition
            {
                Id = Guid.NewGuid(),
                Name = surveyDefinitionDTO.Name,
                Json = surveyDefinitionDTO.Json
            };

            await enlinqdDBContext.SurveyDefinitions.AddAsync(survey, cancellationToken);
            await enlinqdDBContext.SaveChangesAsync();
            return Ok(survey);
        }

        // PATCH api/<SurveysController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, List<PatchCommand> patchCommands, CancellationToken cancellationToken = default)
        {
            SurveyDefinitionDTO updatedSurveyDTO = await _updateSurveyCommandHandler.UpdateSurveyAsync(id, patchCommands, cancellationToken);
            return Ok(updatedSurveyDTO);
        }

        // DELETE api/<SurveysController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var survey = enlinqdDBContext.SurveyDefinitions.SingleOrDefault(s => s.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            enlinqdDBContext.SurveyDefinitions.Remove(survey);
            return Ok();
        }
    }
}
