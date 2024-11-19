using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class AddFunction
{
    [FunctionName("AddFunction")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        
        int num1 = data?.num1;
        int num2 = data?.num2;

        if (num1 == null || num2 == null)
        {
            return new BadRequestObjectResult("Please pass two numbers in the request body.");
        }

        int result = num1 + num2;

        return new OkObjectResult($"The sum of {num1} and {num2} is {result}");
    }
}
