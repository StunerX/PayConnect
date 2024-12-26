#nullable disable
namespace PayConnect.Application.Dto.Merchant.Create.Output;

public class CreateMerchantOutModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LegalName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    public string WebhookUrl { get; set; }
    public string NotificationEmail { get; set; }
    public DateTime CreatedAt { get; set; }
}