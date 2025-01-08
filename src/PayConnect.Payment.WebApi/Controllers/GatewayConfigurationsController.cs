using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;
using PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.Payment.WebApi.Controllers;

[ApiController]
[Route("api/merchants/{merchantId:guid}/gateway-configurations")]
public class GatewayConfigurationsController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<string>))]
    public async Task<ActionResult<CreateGatewayConfigurationResponse>> Create(CreateGatewayConfigurationRequest request, Guid merchantId)
    {
        var command = mapper.Map<CreateGatewayConfigurationCommand>(request);
        command.MerchantId = merchantId;
        
        var result = await mediator.Send(command);

        var response = mapper.Map<CreateGatewayConfigurationResponse>(result);
        
        response.GenerateLinks();
       
        return Created(string.Empty, response);
    }
}