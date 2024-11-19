Function("HttpExample")]
public IActionResult Run([HttpTrigger(AuthorizationLevel.AuthLevelValue, "get", "post")] HttpRequest req)
{
    return new OkObjectResult("Welcome to Azure Functions!");
}
