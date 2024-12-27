using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.GetById;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("api/payment-gateways")]
public class PaymentGatewaysController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
    public async Task<ActionResult<CreatePaymentGatewayResponse>> Create(CreatePaymentGatewayRequest request)
    {
        var command = mapper.Map<CreatePaymentGatewayCommand>(request);
        var result = await mediator.Send(command);

        var response = mapper.Map<CreatePaymentGatewayResponse>(result);
        response.GenerateLinks();

        return Created(nameof(GetById), response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
    public async Task<ActionResult<GetPaymentGatewayByIdResponse>> GetById(Guid id)
    {
        var query = new GetPaymentGatewayByIdQuery { Id = id };
        var result = await mediator.Send(query);
        
        var response = mapper.Map<GetPaymentGatewayByIdResponse>(result);
        response.GenerateLinks();
        
        return Ok(response);
    }
}