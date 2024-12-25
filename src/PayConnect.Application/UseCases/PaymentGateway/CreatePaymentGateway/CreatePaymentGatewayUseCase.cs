using AutoMapper;
using MediatR;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayUseCase(IPaymentGatewayService paymentGatewayService, IMapper mapper)
    : IRequestHandler<CreatePaymentGatewayCommand, CreatePaymentGatewayResult>
{
    public async Task<CreatePaymentGatewayResult> Handle(CreatePaymentGatewayCommand command, CancellationToken cancellationToken)
    {
        var inModel = mapper.Map<CreatePaymentGatewayInModel>(command);
        var outModel = await paymentGatewayService.CreateAsync(inModel, cancellationToken);

        return mapper.Map<CreatePaymentGatewayResult>(outModel);
    }
}