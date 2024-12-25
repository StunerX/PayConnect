using AutoMapper;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.Interfaces;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Application.Services;

public class PaymentGatewayService(IUnitOfWork unitOfWork, IPaymentGatewayDomainService domainService, IMapper mapper) : IPaymentGatewayService
{
    public async Task<CreatePaymentGatewayOutModel> CreateAsync(CreatePaymentGatewayInModel model, CancellationToken cancellationToken = default)
    {
        await domainService.VerifyPaymentGatewayExistsAsync(model.Name, model.BaseUrl);
        
        var entity = PaymentGateway.Create(model.Name, model.BaseUrl, model.Image);
        await unitOfWork.PaymentGatewayRepository.AddAsync(entity);
        await unitOfWork.CommitAsync();
        
        return mapper.Map<CreatePaymentGatewayOutModel>(entity);
    }
}