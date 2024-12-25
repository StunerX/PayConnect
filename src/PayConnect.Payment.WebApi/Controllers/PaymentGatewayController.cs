using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentGatewayController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
    public async Task<ActionResult<CreatePaymentGatewayResponse>> Create(CreatePaymentGatewayRequest request)
    {
        var command = new CreatePaymentGatewayCommand
        {
            Data = new CreatePaymentGatewayInModel
            {
                Name = request.Name,
                BaseUrl = request.BaseUrl,
                Image = request.Image
            }
        };
        var result = await mediator.Send(command);
        
        var response = new CreatePaymentGatewayResponse
        {
            Id = result.Id,
            Name = request.Name,
            BaseUrl = request.BaseUrl,
            Image = request.Image
        };
        
        return Created(string.Empty, response);
    }
}