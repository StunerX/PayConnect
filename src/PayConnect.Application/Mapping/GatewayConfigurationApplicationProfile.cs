using AutoMapper;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Input;
using PayConnect.Application.Dto.GatewayConfiguration.Create.Output;
using PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;
using PayConnect.Domain.Entities;

namespace PayConnect.Application.Mapping;

public class GatewayConfigurationApplicationProfile : Profile
{
    public GatewayConfigurationApplicationProfile()
    {
        #region CreateGatewayConfiguration

        // Mapeamento para os itens individuais
        CreateMap<GatewayConfiguration, CreateGatewayConfigurationItemOutModel>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.IsSensitive ? "********" : src.Value))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

        // Mapeamento para o modelo de saída
        CreateMap<List<GatewayConfiguration>, CreateGatewayConfigurationOutModel>()
            .ForMember(dest => dest.MerchantId, opt => opt.MapFrom(src => src.FirstOrDefault()!.MerchantId))
            .ForMember(dest => dest.PaymentGatewayId, opt => opt.MapFrom(src => src.FirstOrDefault()!.PaymentGatewayId))
            .ForMember(dest => dest.Configurations, opt => opt.MapFrom(src => src));
        
        CreateMap<CreateGatewayConfigurationCommand, CreateGatewayConfigurationInModel>();
        CreateMap<CreateGatewayConfigurationItemCommand, CreateGatewayConfigurationItemInModel>();
        CreateMap<CreateGatewayConfigurationOutModel, CreateGatewayConfigurationResult>();
        CreateMap<CreateGatewayConfigurationItemOutModel, CreateGatewayConfigurationItemResult>();

        #endregion
    }
}