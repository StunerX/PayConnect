using MediatR;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayUseCase(IPaymentGatewayService paymentGatewayService)
    : IRequestHandler<CreatePaymentGatewayCommand, CreatePaymentGatewayResult>
{
    public async Task<CreatePaymentGatewayResult> Handle(CreatePaymentGatewayCommand command, CancellationToken cancellationToken)
    {
        var outModel = await paymentGatewayService.CreateAsync(command.Data, cancellationToken);

        return new CreatePaymentGatewayResult { Id = outModel.Id};
    }
}