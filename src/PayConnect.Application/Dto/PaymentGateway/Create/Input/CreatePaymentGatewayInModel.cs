#nullable disable
namespace PayConnect.Application.Dto.PaymentGateway.Create.Input;

public class CreatePaymentGatewayInModel
{
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string Image { get; set; }
}