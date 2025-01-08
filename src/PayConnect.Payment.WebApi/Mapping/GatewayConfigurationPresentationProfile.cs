using AutoMapper;
using PayConnect.Application.UseCases.GatewayConfiguration.CreateGatewayConfiguration;
using PayConnect.Payment.WebApi.Contracts.GatewayConfiguration.Create;


namespace PayConnect.Payment.WebApi.Mapping;

public class GatewayConfigurationPresentationProfile : Profile
{
    public GatewayConfigurationPresentationProfile()
    {
        CreateMap<CreateGatewayConfigurationRequest, CreateGatewayConfigurationCommand>();
        CreateMap<CreateGatewayConfigurationItemRequest, CreateGatewayConfigurationItemCommand>();
        CreateMap<CreateGatewayConfigurationResult, CreateGatewayConfigurationResponse>();
        CreateMap<CreateGatewayConfigurationItemResult, CreateGatewayConfigurationItemResponse>();
    }
}