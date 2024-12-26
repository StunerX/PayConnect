using AutoMapper;
using PayConnect.Application.Dto.Merchant.Create.Input;
using PayConnect.Application.Dto.Merchant.Create.Output;
using PayConnect.Application.UseCases.Merchant.CreateMerchant;
using PayConnect.Domain.Entities;

namespace PayConnect.Application.Mapping;

public class MerchantMappingApplicationProfile : Profile
{
    public MerchantMappingApplicationProfile()
    {
        #region CreateMerchant
        
        CreateMap<Merchant, CreateMerchantOutModel>();
        CreateMap<CreateMerchantCommand, CreateMerchantInModel>();
        CreateMap<CreateMerchantOutModel, CreateMerchantResult>();

        #endregion
    }
}