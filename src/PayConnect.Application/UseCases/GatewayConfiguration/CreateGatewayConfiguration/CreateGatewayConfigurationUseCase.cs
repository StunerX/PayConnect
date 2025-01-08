using AutoMapper;
using MediatR;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Input;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;

public class CreateGatewayConfigurationUseCase(IGatewayConfigurationService service, IMapper mapper) : IRequestHandler<CreateGatewayConfigurationCommand, CreateGatewayConfigurationResult>
{
    public async Task<CreateGatewayConfigurationResult> Handle(CreateGatewayConfigurationCommand request, CancellationToken cancellationToken)
    {
        var inModel = mapper.Map<CreateGatewayConfigurationInModel>(request);
        var outModel = await service.CreateAsync(inModel, cancellationToken);
        return mapper.Map<CreateGatewayConfigurationResult>(outModel);
    }
}