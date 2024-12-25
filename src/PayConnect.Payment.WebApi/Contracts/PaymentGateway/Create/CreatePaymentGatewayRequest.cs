namespace PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

public class CreatePaymentGatewayRequest
{
    public string Name { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
    public string? Image { get; set; }
}