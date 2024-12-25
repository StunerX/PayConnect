using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.Dto.PaymentGateway.GetPaymentGatewayById.Output;

namespace PayConnect.Application.Interfaces;

public interface IPaymentGatewayService
{
    Task<CreatePaymentGatewayOutModel> CreateAsync(CreatePaymentGatewayInModel model, CancellationToken cancellationToken = default);
    Task<GetPaymentGatewayByIdOutModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}