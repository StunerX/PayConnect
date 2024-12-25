#nullable disable
using MediatR;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayCommand : IRequest<CreatePaymentGatewayResult>
{
    public string Name { get; set; }
    public string BaseUrl { get; set; }
    public string Image { get; set; }
}