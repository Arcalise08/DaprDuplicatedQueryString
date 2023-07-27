using Microsoft.AspNetCore.Mvc;

namespace DaprProblem.Two.MyController;

[ApiController]
[Route("/api/controllerTwo")]
[Produces("application/json")]
public class MyController : Controller
{
    [Route("getValue")]
    public async Task<IActionResult> GetValue(string code)
    {
        return Ok("one");
    }
}
