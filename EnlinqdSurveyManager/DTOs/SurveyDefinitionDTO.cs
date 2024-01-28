using EnlinqdSurveyManager.Domain.Models;

namespace EnlinqdSurveyManager.DTOs
{
    public class SurveyDefinitionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }

        public SurveyDefinitionDTO() { }

        public SurveyDefinitionDTO(SurveyDefinition surveyDefinition)
        {
            Id = surveyDefinition.Id;
            Name = surveyDefinition.Name;
            Json = surveyDefinition.Json;
        }

    }
}
