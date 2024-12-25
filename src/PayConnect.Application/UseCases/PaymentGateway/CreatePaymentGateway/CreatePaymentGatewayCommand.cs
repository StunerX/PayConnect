using MediatR;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayCommand : IRequest<CreatePaymentGatewayResult>
{
    public required CreatePaymentGatewayInModel Data { get; init; }
}