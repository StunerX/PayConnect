#nullable disable
namespace PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;

public class CreateGatewayConfigurationItemResult
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
    public DateTime CreatedAt { get; set; }
}