using EnlinqdSurveyManager.Domain.Models;
using EnlinqdSurveyManager.DTOs;
using EnlinqdSurveyManager.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnlinqdSurveyManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        #region Private Fields

        private readonly ISurveyQueries _surveyQueries;
        private SurveyDBContext surveyDBContext;

        #endregion Private Fields

        public SurveysController(SurveyDBContext dbContext, SurveyQueries surveyQueries)
        {
            this.surveyDBContext = dbContext;
            _surveyQueries = surveyQueries;
        }

        // GET: api/<SurveysController>
        [HttpGet("summary")]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await surveyDBContext.SurveyDefinitions.ToListAsync());
        }

        // GET api/<SurveysController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var survey = await surveyDBContext.SurveyDefinitions.FindAsync(id);
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

            await surveyDBContext.SurveyDefinitions.AddAsync(survey,cancellationToken);
            await surveyDBContext.SaveChangesAsync();
            return Ok(survey);
        }

        // PATCH api/<SurveysController>/5
        [HttpPatch("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveysController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
