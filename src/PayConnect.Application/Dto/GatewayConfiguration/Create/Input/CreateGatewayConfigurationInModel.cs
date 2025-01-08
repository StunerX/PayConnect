#nullable disable
namespace PayConnect.Application.Dto.GatewayConfiguration.Create.Input;

public class CreateGatewayConfigurationInModel
{
    public Guid MerchantId { get; set; }
    public Guid PaymentGatewayId { get; set; }

    public List<CreateGatewayConfigurationItemInModel> Configurations { get; set; } = [];
}