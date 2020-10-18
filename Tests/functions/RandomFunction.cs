using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace functions
{
    public static class RandomFunction
    {

        [FunctionName("Cube")]
        public static async Task<IActionResult> Cube(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            dynamic data = JsonConvert.DeserializeObject(await req.ReadAsStringAsync());
            int input = data.Num;
            int response = PowerCube(input);
            log.LogInformation($"{input} cube is {response}");
            return new OkObjectResult(response);
        }

        private static int PowerCube(int x)
        {
            return x*x*x;
        }
    }
}
