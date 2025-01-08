#nullable disable
namespace PayConnect.Application.Dto.GatewayConfiguration.Create.Output;

public class CreateGatewayConfigurationItemOutModel
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
    public DateTime CreatedAt { get; set; }
}