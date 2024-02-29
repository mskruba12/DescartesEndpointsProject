using DescartesEndpointsProject.Classes;
using DescartesEndpointsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DescartesEndpointsProject.Controllers
{
    [ApiController]
    [Route("v1/diff/{ID}")]
    public class DiffController : ControllerBase
    {
        private static Dictionary<int, ReceivedData> leftData = new Dictionary<int, ReceivedData>();
        private static Dictionary<int, ReceivedData> rightData = new Dictionary<int, ReceivedData>();
        private readonly IDataService _dataService;

        public DiffController(IDataService dataService)
        {
            _dataService = dataService;

            leftData = dataService.GetLeftData();
            rightData = dataService.GetRightData();
        }


        [HttpGet]
        public IActionResult GetDiff(int ID)
        {
            // Get left and right data based on ID and check if they exist
            if (leftData[ID] == null || rightData[ID] == null)
            {
                return NotFound($"Data not found for ID {ID}");
            }

            // Check the difference
            var diffResult = CheckDiff(leftData[ID].Data, rightData[ID].Data);

            // Return the difference result
            return Ok(diffResult);
        }

        private object CheckDiff(string leftData, string rightData)
        {
            StringDiffResult res = new StringDiffResult();

            if (string.Equals(leftData, rightData))
            {
                res.DiffResultType = "ContentMatch";
            }
            else
            {
                res.DiffResultType = "ContentDoNotMatch";
                res.Diffs = GetStringDifferences(leftData, rightData);
            }

            return res;
        }

        private List<DiffDetail> GetStringDifferences(string leftData, string rightData)
        {
            List<DiffDetail> differences = new List<DiffDetail>();
            int offset = 0;
            //Calculates the difference in length between the 2 strings
            int lengthDiff = Math.Abs(leftData.Length - rightData.Length);

            //Checks each character of the strings for differences.
            for (int i = 0; i < leftData.Length; i++)
            {
                if (!Equals(leftData[i], rightData[i]))
                {
                    offset++;
                }
            }

            differences.Add(new DiffDetail
            {
                Offset = offset,
                Length = lengthDiff
            });

            return differences;
        }
    }
}
