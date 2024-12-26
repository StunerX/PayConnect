using AutoMapper;
using PayConnect.Application.Dto.Merchant.Create.Output;
using PayConnect.Domain.Entities;

namespace PayConnect.Application.Mapping;

public class MerchantMappingApplicationProfile : Profile
{
    public MerchantMappingApplicationProfile()
    {
        CreateMap<Merchant, CreateMerchantOutModel>();
    }
}