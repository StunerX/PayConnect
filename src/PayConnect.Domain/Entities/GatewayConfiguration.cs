using PayConnect.Domain.Common;

namespace PayConnect.Domain.Entities;

public class GatewayConfiguration : Entity
{
    public Guid MerchantId { get; private set; }
    public Guid PaymentGatewayId { get; private set; }
    public required string Key { get; init; }
    public required string Value { get; init; }
    public bool IsSensitive { get; private set; }
    public virtual Merchant Merchant { get; private set; } = null!;
    public virtual PaymentGateway PaymentGateway { get; private set; } = null!;
    
    public static GatewayConfiguration Create(Guid merchantId, Guid paymentGatewayId, string key, string value, bool isSensitive = false)
    {
        return new GatewayConfiguration
        {
            Id = Guid.NewGuid(),
            MerchantId = merchantId,
            PaymentGatewayId = paymentGatewayId,
            Key = key,
            Value = value,
            IsSensitive = isSensitive,
            CreatedAt = DateTime.UtcNow
        };
    }
}