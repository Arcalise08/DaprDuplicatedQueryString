using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprProblem.Two.MyController;

[ApiController]
[Route("/api/controllerOne")]
[Produces("application/json")]
public class MyController : Controller
{
    private readonly DaprClient Dapr;
    public MyController(DaprClient daprClient)
    {
        Dapr = daprClient;
    }
    [Route("getValue")]
    public async Task<IActionResult> GetValue()
    {
        var request = 
            Dapr.CreateInvokeMethodRequest("dapr2", "api/controllerTwo/getValue?code=testFacility");
        await Dapr.InvokeMethodAsync(request);
        return Ok();
    }
}