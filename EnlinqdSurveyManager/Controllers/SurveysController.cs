﻿using EnlinqdSurveyManager.Application.Commands;
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

        //private readonly ISurveyQueries _surveyQueries;
        private readonly SurveyDBContext surveyDBContext;
        private readonly IUpdateSurveyCommandHandler _updateSurveyCommandHandler;

        #endregion Private Fields

        //public SurveysController(SurveyDBContext dbContext, SurveyQueries surveyQueries)
        public SurveysController(SurveyDBContext dbContext,
            IUpdateSurveyCommandHandler updateSurveyCommandHandler)
        {
            this.surveyDBContext = dbContext;
            _updateSurveyCommandHandler = updateSurveyCommandHandler;
            //_surveyQueries = surveyQueries;
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

            await surveyDBContext.SurveyDefinitions.AddAsync(survey, cancellationToken);
            await surveyDBContext.SaveChangesAsync();
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

            var survey = surveyDBContext.SurveyDefinitions.SingleOrDefault(s => s.Id == id);
            if (survey == null)
            {
                return NotFound();
            }

            surveyDBContext.SurveyDefinitions.Remove(survey);
            return Ok();
        }
    }
}
