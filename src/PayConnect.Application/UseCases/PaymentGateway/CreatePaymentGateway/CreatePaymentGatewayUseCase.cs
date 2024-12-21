using MediatR;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

public class CreatePaymentGatewayUseCase(IPaymentGatewayService paymentGatewayService) : IRequestHandler<CreatePaymentGatewayRequest, CreatePaymentGatewayResponse>
{
    public async Task<CreatePaymentGatewayResponse> Handle(CreatePaymentGatewayRequest request, CancellationToken cancellationToken)
    {
        var response = new CreatePaymentGatewayResponse();

        try
        {
            response.Data = await paymentGatewayService.CreateAsync(request.Data, cancellationToken);

            return response;
        }
        catch (Exception ex)
        {
            response.Data = null;
            response.Error = ex.Message;
            response.HasError = true;

            return response;
        }
    }
}