using DescartesEndpointsProject.Classes;
using DescartesEndpointsProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DescartesEndpointsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private static Dictionary<int, ReceivedData> leftData = new Dictionary<int, ReceivedData>();
        private static Dictionary<int, ReceivedData> rightData = new Dictionary<int, ReceivedData>();
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;

            //Reads any already existing data
            leftData = dataService.GetLeftData();
            rightData = dataService.GetRightData();
        }

        [HttpPost("left")]
        public IActionResult SetLeftData(int ID, [FromBody] ReceivedData receivedData)
        {
            _dataService.SetLeftDataById(ID, receivedData);

            return new ObjectResult(leftData) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPost("right")]
        public IActionResult SetRightData(int ID, [FromBody] ReceivedData receivedData)
        {
            _dataService.SetRightDataById(ID, receivedData);

            return new ObjectResult(rightData) { StatusCode = StatusCodes.Status201Created };
        }
    }


}