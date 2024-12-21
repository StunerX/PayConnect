using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;

namespace PayConnect.Application.Interfaces;

public interface IPaymentGatewayService
{
    Task<CreatePaymentGatewayOutModel> CreateAsync(CreatePaymentGatewayInModel model, CancellationToken cancellationToken = default);
}