namespace PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;

public class CreateGatewayConfigurationRequest
{
    public Guid PaymentGatewayId { get; set; }
    public List<CreateGatewayConfigurationItemRequest> Configurations { get; set; } = [];
}