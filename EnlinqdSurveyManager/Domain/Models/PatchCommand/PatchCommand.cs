namespace EnlinqdSurveyManager.Domain.Models.PatchCommand
{
    public class PatchCommand
    {
        public string Command { get; set; }
        public string Value { get; set; }
        public IEnumerable<PatchCommandFilter> PatchCommandFilters { get; set; }

        public PatchCommand() { }
    }
}
