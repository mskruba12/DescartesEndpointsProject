using static DescartesEndpointsProject.Controllers.DiffController;

namespace DescartesEndpointsProject.Classes
{
    public class StringDiffResult
    {
        public string DiffResultType { get; set; }
        public List<DiffDetail> Diffs { get; set; }
    }
}
