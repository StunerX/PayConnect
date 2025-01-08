#nullable disable
using PayConnect.Presentation.Shared.Hateoas;
using PayConnect.Presentation.Shared.Http;

namespace PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;

public class CreateGatewayConfigurationItemResponse : ResponseBase
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsSensitive { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public void GenerateLinks(Guid merchantId, Guid paymentGatewayId)
    {
        var link = GatewayConfigurationUrl.GetGatewayConfigurationItemUrl(merchantId, paymentGatewayId, Id);
        
        Links.Add(LinkTemplate.CreateLink("self", link));
        Links.Add(LinkTemplate.CreateLink("update", link, null, "PUT"));
        Links.Add(LinkTemplate.CreateLink("delete", link, null, "DELETE"));
    }

    public override void GenerateLinks()
    {
    }
}