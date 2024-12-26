using MediatR;

namespace PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

public class GetPaymentGatewayByIdQuery : IRequest<GetPaymentGatewayByIdResult>
{
    public Guid Id { get; set; }
}