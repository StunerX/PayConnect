using AutoMapper;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.GetById;

namespace PayConnect.Payment.WebApi.Mapping;

public class PaymentGatewayPresentationProfile : Profile
{
    public PaymentGatewayPresentationProfile()
    {
        #region CreatePayment

        CreateMap<CreatePaymentGatewayRequest, CreatePaymentGatewayCommand>();
        CreateMap<CreatePaymentGatewayResult, CreatePaymentGatewayResponse>();

        #endregion

        #region GetById

        CreateMap<GetPaymentGatewayByIdResult, GetPaymentGatewayByIdResponse>();

        #endregion

    }
}