using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreatePaymentGatewayResponse>> Create(CreatePaymentGatewayRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
}