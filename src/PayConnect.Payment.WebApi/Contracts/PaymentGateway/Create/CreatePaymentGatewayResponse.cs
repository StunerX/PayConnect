using WebApi.Hal;

namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

public class CreatePaymentGatewayResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string? Image { get; set; }
    public List<Link> Links { get; set; } = [];

    public void AddLink(string rel, string href, string method)
    {
        Links.Add(new Link(rel, href, method));
    }
}