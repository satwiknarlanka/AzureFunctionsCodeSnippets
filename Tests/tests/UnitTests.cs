using functions;
using Microsoft.Extensions.Logging;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace tests
{

    public class UnitTests 
    {
        [Theory]
        [InlineData(2,8)]
        [InlineData(3,27)]
        [InlineData(1,1)]
        public async Task Cube_ShouldReturnCube(int input,int expected)
        {
            //Arrange
            var req = FakeHttpRequest.FakeHttpRequestWithObject(new {Num=input});
            var log = new FakeListLogger();
            //Act
            var response = (OkObjectResult)await RandomFunction.Cube(req,log);
            //Assert
            response.StatusCode.Should().Be((int)HttpStatusCode.OK);
            response.Value.Should().Be(expected);
            log.Logs[0].Should().Be($"{input} cube is {expected}");
        }
    }
}
