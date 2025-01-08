#nullable disable
namespace PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;

public class CreateGatewayConfigurationItemCommand
{
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
}