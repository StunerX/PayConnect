#nullable disable
using PayConnect.Presentation.Shared.Hateoas;
using PayConnect.Presentation.Shared.Http;

namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.GetById;

public class GetPaymentGatewayByIdResponse : ResponseBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BaseUrl { get; init; }
    public string Image { get; init; }
    public DateTime CreatedAt { get; set; }
    public override void GenerateLinks()
    {
        Links.Add(LinkTemplate.CreateLink("self", $"/api/payment-gateways/{Id}"));
        Links.Add(LinkTemplate.CreateLink("update", $"/api/payment-gateways/{Id}", null, "PUT"));
        Links.Add(LinkTemplate.CreateLink("delete", $"/api/payment-gateways/{Id}", null, "DELETE"));
        Links.Add(LinkTemplate.CreateLink("list", "/api/payment-gateways"));
    }
}