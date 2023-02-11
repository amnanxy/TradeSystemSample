using Microsoft.AspNetCore.Mvc;
using TradeSystem.Services.Captures;
using TradeSystem.Services.Refunds;

namespace TradeSystem.Controllers;

[ApiController]
[Route("/[controller]")]
public class TradeController : ControllerBase
{
    [HttpPost]
    [Route("[action]")]
    public IActionResult Capture(
        [FromBody] int tradeId,
        [FromServices] ICaptureService service
    )
    {
        service.Handle(tradeId);
        return Ok();
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Refund(
        [FromBody] int tradeId,
        [FromServices] IRefundService service
    )
    {
        service.Handle(tradeId);
        return Ok();
    }
}