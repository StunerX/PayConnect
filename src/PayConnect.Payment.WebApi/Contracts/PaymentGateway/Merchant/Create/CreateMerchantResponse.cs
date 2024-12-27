#nullable disable

using PayConnect.Presentation.Shared.Hateoas;
using PayConnect.Presentation.Shared.Http;

namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;

public class CreateMerchantResponse : ResponseBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }

    public override void GenerateLinks()
    {
        Links.Add(LinkTemplate.CreateLink("self", $"/api/v1/merchants/{Id}"));
        Links.Add(LinkTemplate.CreateLink("list", "/api/v1/merchants"));
    }
}