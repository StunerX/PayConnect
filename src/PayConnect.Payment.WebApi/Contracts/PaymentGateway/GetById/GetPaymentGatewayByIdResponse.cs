#nullable disable
namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.GetById;

public class GetPaymentGatewayByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BaseUrl { get; init; }
    public string Image { get; init; }
    public DateTime CreatedAt { get; set; }
}