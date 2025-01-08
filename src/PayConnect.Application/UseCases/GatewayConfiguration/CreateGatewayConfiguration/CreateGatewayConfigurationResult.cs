namespace PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;

public class CreateGatewayConfigurationResult
{
    public Guid MerchantId { get; set; }
    public Guid PaymentGatewayId { get; set; }
   
    public List<CreateGatewayConfigurationItemResult> Configurations { get; set; } = [];
}