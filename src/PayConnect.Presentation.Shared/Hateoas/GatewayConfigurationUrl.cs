namespace PayConnect.Presentation.Shared.Hateoas;

public static class GatewayConfigurationUrl
{
    public static string GetGatewayConfigurationUrl(Guid merchantId, Guid paymentGatewayId)
    {
        return $"/api/v1/merchants/{merchantId}/gateway-configurations/{paymentGatewayId}";
    }
    
    public static string GetGatewayConfigurationItemUrl(Guid merchantId, Guid paymentGatewayId, Guid id)
    {
        return $"/api/v1/merchants/{merchantId}/gateway-configurations/{paymentGatewayId}/{id}";
    }
}