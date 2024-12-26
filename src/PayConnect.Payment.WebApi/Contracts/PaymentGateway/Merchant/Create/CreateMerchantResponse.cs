#nullable disable
using WebApi.Hal;

namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;

public class CreateMerchantResponse
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
    public List<Link> Links { get; set; } = [];

    public void AddLink(string rel, string href, string method)
    {
        Links.Add(new Link(rel, href, method));
    }
}