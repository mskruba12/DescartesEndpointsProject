using DescartesEndpointsProject.Classes;
using DescartesEndpointsProject.Controllers;
using DescartesEndpointsProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescartestEndpointsProjectTests
{
    public class DiffControllerTests
    {
        static Mock<IDataService> dataServiceMock = new Mock<IDataService>();

        [Fact]
        public void GetDiff_ReturnsOkResultWithEqualData()
        {
            //Set up the data for comparisson 
            ReceivedData testData = new ReceivedData { Data = "TestData" };
            Dictionary<int, ReceivedData> receivedTestData= new Dictionary<int, ReceivedData>();
            receivedTestData.Add(1, testData);

            //Make the mock return the previously set up data
            dataServiceMock.Setup(ds => ds.GetLeftData()).Returns(receivedTestData);
            dataServiceMock.Setup(ds => ds.GetRightData()).Returns(receivedTestData);

            DiffController diffController = new DiffController(dataServiceMock.Object);

            var res = diffController.GetDiff(1);

            Assert.NotNull(res);

            //Get the data from the result to check if it is correct
            var diffResult = Assert.IsType<StringDiffResult>(((OkObjectResult)res).Value);

            Assert.Null(diffResult.Diffs);
        }

        [Fact]
        public void GetDiff_ReturnsOkResultWithDifferences()
        {
            //Set up the 2 different datas to compare 
            ReceivedData testDataLeft = new ReceivedData { Data = "TestData1" };
            ReceivedData testDataRight = new ReceivedData { Data = "TestData21" };
            Dictionary<int, ReceivedData> receivedTestDataLeft = new Dictionary<int, ReceivedData>();
            receivedTestDataLeft.Add(1, testDataLeft);
            Dictionary<int, ReceivedData> receivedTestDataRight = new Dictionary<int, ReceivedData>();
            receivedTestDataRight.Add(1, testDataRight);

            //Make the mock return the previously set up data
            dataServiceMock.Setup(ds => ds.GetLeftData()).Returns(receivedTestDataLeft);
            dataServiceMock.Setup(ds => ds.GetRightData()).Returns(receivedTestDataRight);

            DiffController diffController = new DiffController(dataServiceMock.Object);

            var res = diffController.GetDiff(1);

            Assert.NotNull(res);

            //Get the data from the result to check if it is correct
            var diffResult = Assert.IsType<StringDiffResult>(((OkObjectResult)res).Value);

            Assert.Equal(2, diffResult.Diffs[0].Offset);
            Assert.Equal(1, diffResult.Diffs[0].Length);
        }
    }
}
