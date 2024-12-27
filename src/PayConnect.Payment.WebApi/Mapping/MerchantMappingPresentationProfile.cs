using AutoMapper;
using PayConnect.Application.UseCases.Merchant.CreateMerchant;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;

namespace PayConnect.Payment.WebApi.Mapping;

public class MerchantMappingPresentationProfile : Profile
{
    public MerchantMappingPresentationProfile()
    {
        #region Create

        CreateMap<CreateMerchantRequest, CreateMerchantCommand>();
        CreateMap<CreateMerchantResult, CreateMerchantResponse>();

        #endregion
    }
}