using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.Interfaces;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Application.Services;

public class PaymentGatewayService(IUnitOfWork unitOfWork) : IPaymentGatewayService
{
    public async Task<CreatePaymentGatewayOutModel> CreateAsync(CreatePaymentGatewayInModel model, CancellationToken cancellationToken = default)
    {
        var entity = PaymentGateway.Create(model.Name, model.BaseUrl, model.Image);
        await unitOfWork.PaymentGatewayRepository.AddAsync(entity);
        await unitOfWork.CommitAsync();
        
        return new CreatePaymentGatewayOutModel { Id = entity.Id};
    }
}