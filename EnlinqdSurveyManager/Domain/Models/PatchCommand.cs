namespace EnlinqdSurveyManager.Domain.Models
{
    public class PatchCommand
    {
        public string Command { get; set; }
        public string Value { get; set; }
        public IEnumerable<PatchCommandFilter> PatchCommandFilters { get; set; }

        public PatchCommand() { }
    }
}
