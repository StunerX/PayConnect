#nullable disable
namespace PayConnect.Application.Dto.GatewayConfiguration.Create.Input;

public class CreateGatewayConfigurationItemInModel
{
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
}