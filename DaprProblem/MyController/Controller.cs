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
    [Route("fireMethodWithDapr")]
    public async Task<IActionResult> fireMethodWithDapr([FromQuery] string code)
    {
        var request = 
            Dapr.CreateInvokeMethodRequest(HttpMethod.Get, "dapr2", $"api/controllerTwo/getValue?code={code}");
        var response = await Dapr.InvokeMethodAsync<string>(request);
        return Ok(response);
    }

    [Route("fireMethodWithoutDapr")]
    public async Task<IActionResult> fireMethodWithoutDapr([FromQuery] string code)
    {
        var client = new HttpClient()
        {
            BaseAddress = new Uri("http://daprproblem-two")
        };
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/controllerTwo/getValue?code={code}");
        var response = await client.SendAsync(request);
        
        return Ok(await response.Content.ReadFromJsonAsync<string>());
    }
}