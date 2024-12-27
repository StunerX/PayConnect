#nullable disable
namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;

public class CreateMerchantRequest
{
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
}