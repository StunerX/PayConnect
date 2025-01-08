#nullable disable
using MediatR;

namespace PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;

public class CreateGatewayConfigurationCommand : IRequest<CreateGatewayConfigurationResult>
{
    public Guid MerchantId { get; set; }
    public Guid PaymentGatewayId { get; set; }
    public List<CreateGatewayConfigurationItemCommand> Configurations { get; set; } = [];

}