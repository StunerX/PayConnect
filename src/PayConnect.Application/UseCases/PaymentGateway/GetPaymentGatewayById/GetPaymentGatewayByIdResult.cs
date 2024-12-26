#nullable disable
namespace PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

public class GetPaymentGatewayByIdResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BaseUrl { get; init; }
    public string Image { get; init; }
    public DateTime CreatedAt { get; set; }
}