using AutoMapper;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

namespace PayConnect.Application.Mapping;

public class PaymentGatewayApplicationProfile : Profile
{
    public PaymentGatewayApplicationProfile()
    {
        CreateMap<Domain.Entities.PaymentGateway, CreatePaymentGatewayOutModel>();
        CreateMap<CreatePaymentGatewayCommand, CreatePaymentGatewayInModel>();
        CreateMap<CreatePaymentGatewayOutModel, CreatePaymentGatewayResult>();
    }
}