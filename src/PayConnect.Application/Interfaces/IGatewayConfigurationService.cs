using PayConnect.Application.Dto.GatewayConfiguration.Create.Input;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Output;

namespace PayConnect.Application.Interfaces;

public interface IGatewayConfigurationService
{
    Task<CreateGatewayConfigurationOutModel> CreateAsync(CreateGatewayConfigurationInModel model, CancellationToken cancellationToken);
}