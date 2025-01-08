using PayConnect.Presentation.Shared.Hateoas;
using PayConnect.Presentation.Shared.Http;

namespace PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;

public class CreateGatewayConfigurationResponse : ResponseBase
{
    public Guid MerchantId { get; set; }
    public Guid PaymentGatewayId { get; set; }
    
    public List<CreateGatewayConfigurationItemResponse> Configurations { get; set; } = [];

    public override void GenerateLinks()
    {
        var link = GatewayConfigurationUrl.GetGatewayConfigurationUrl(MerchantId, PaymentGatewayId);
        Links.Add(LinkTemplate.CreateLink("self", link));
        
        foreach (var configuration in Configurations)
        {
            configuration.GenerateLinks(MerchantId, PaymentGatewayId);
        }
    }
}