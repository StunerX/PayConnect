using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreatePaymentGatewayResult>> Create(CreatePaymentGatewayCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}