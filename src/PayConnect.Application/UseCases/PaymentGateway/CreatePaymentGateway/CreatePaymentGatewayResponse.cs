using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.Shared.Response;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayResponse : ResponseBase<CreatePaymentGatewayOutModel>
{
    public CreatePaymentGatewayResponse() => Data = new CreatePaymentGatewayOutModel();
}