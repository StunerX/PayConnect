#nullable disable
namespace PayConnect.Application.Dto.GatewayConfiguration.Create.Output;

public class CreateGatewayConfigurationOutModel
{
    public Guid MerchantId { get; set; }
    public Guid PaymentGatewayId { get; set; }
    
    public List<CreateGatewayConfigurationItemOutModel> Configurations { get; set; } = [];
}