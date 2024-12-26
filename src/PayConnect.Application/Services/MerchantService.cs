using AutoMapper;
using PayConnect.Application.Dto.Merchant.Create.Input;
using PayConnect.Application.Dto.Merchant.Create.Output;
using PayConnect.Application.Interfaces;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Application.Services;

public class MerchantService(IMerchantDomainService domainService, IUnitOfWork unitOfWork, IMapper mapper) : IMerchantService
{
    public async Task<CreateMerchantOutModel> CreateAsync(CreateMerchantInModel model, CancellationToken cancellationToken = default)
    {
        await domainService.VerifyMerchantExistsAsync(model.Document, cancellationToken);
        
        var merchant = Merchant.Create(model.Name, model.LegalName, model.Email, model.Phone, model.Document, model.Country, model.Currency);
        
        await unitOfWork.MerchantRepository.AddAsync(merchant);

        await unitOfWork.CommitAsync();
        
        return mapper.Map<CreateMerchantOutModel>(merchant);
    }
}