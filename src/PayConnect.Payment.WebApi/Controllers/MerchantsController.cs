using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.UseCases.Merchant.CreateMerchant;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("api/merchants")]
public class MerchantsController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
    public async Task<ActionResult<CreateMerchantResponse>> Create(CreateMerchantRequest request)
    {
        var command = mapper.Map<CreateMerchantCommand>(request);
        var result = await mediator.Send(command);

        var response = mapper.Map<CreateMerchantResponse>(result);
        
        response.GenerateLinks();
       
        return Created(string.Empty, response);
    }
}