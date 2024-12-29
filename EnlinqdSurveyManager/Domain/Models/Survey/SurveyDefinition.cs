namespace EnlinqdSurveyManager.Domain.Models.Survey
{
    public class SurveyDefinition
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Json { get; set; }

        public SurveyDefinition() { }

        public SurveyDefinition(Guid id, string name, string json)
        {
            SetId(id);
            SetName(name);
            SetJson(json);
        }

        private SurveyDefinition SetId(Guid id)
        {
            if (id == Guid.Empty || id == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                Id = Guid.NewGuid();
            }
            else
            {
                Id = id;
            }

            return this;
        }

        private SurveyDefinition SetName(string name)
        {
            Name = name;
            return this;
        }

        private SurveyDefinition SetJson(string json)
        {
            Json = json;
            return this;
        }
    }
}
