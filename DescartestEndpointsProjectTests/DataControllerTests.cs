using DescartesEndpointsProject.Classes;
using DescartesEndpointsProject.Controllers;
using DescartesEndpointsProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DescartestEndpointsProjectTests
{
    public class DataControllerTests
    {
        static Mock<IDataService> dataServiceMock = new Mock<IDataService>();
        DataController dataController = new DataController(dataServiceMock.Object);

        [Fact]
        public void SetLeftData_ReturnsOkResult()
        {
            //Set up the data that will be set
            ReceivedData receivedData = new ReceivedData { Data = "LeftData" };

            var res = dataController.SetLeftData(1, receivedData);

            var objectResult = (ObjectResult)res;

            Assert.IsType<ObjectResult>(res);
            Assert.Equal(201, objectResult.StatusCode);
            dataServiceMock.Verify(ds => ds.SetLeftDataById(1, receivedData), Times.Once);
        }

        [Fact]
        public void SetRightData_ReturnsOkResult()
        {
            ReceivedData receivedData = new ReceivedData { Data = "RightData" };

            var res = dataController.SetRightData(1, receivedData);

            var objectResult = (ObjectResult)res;

            Assert.IsType<ObjectResult>(res);
            Assert.Equal(201, objectResult.StatusCode);
            dataServiceMock.Verify(ds => ds.SetRightDataById(1, receivedData), Times.Once);
        }
    }
}