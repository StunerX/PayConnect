#nullable disable
namespace PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;

public class CreateGatewayConfigurationItemRequest
{
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
}