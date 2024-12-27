
using PayConnect.Presentation.Shared.Hateoas;
using PayConnect.Presentation.Shared.Http;

namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

public class CreatePaymentGatewayResponse : ResponseBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string? Image { get; set; }

    public override void GenerateLinks()
    {
        Links.Add(LinkTemplate.CreateLink("self", $"/api/payment-gateways/{Id}"));
        Links.Add(LinkTemplate.CreateLink("list", "/api/payment-gateways"));
    }
}