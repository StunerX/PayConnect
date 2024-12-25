using AutoMapper;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

namespace PayConnect.Payment.WebApi.Mapping;

public class PaymentGatewayPresentationProfile : Profile
{
    public PaymentGatewayPresentationProfile()
    {
        CreateMap<CreatePaymentGatewayRequest, CreatePaymentGatewayCommand>();
        CreateMap<CreatePaymentGatewayResult, CreatePaymentGatewayResponse>();
    }
}