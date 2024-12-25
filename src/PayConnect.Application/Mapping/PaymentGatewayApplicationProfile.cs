using AutoMapper;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Dto.PaymentGateway.Create.Output;
using PayConnect.Application.Dto.PaymentGateway.GetPaymentGatewayById.Output;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

namespace PayConnect.Application.Mapping;

public class PaymentGatewayApplicationProfile : Profile
{
    public PaymentGatewayApplicationProfile()
    {
        #region CreatePayment

        CreateMap<Domain.Entities.PaymentGateway, CreatePaymentGatewayOutModel>();
        CreateMap<CreatePaymentGatewayCommand, CreatePaymentGatewayInModel>();
        CreateMap<CreatePaymentGatewayOutModel, CreatePaymentGatewayResult>();

        #endregion

        #region GetPaymentGatewayById

        CreateMap<Domain.Entities.PaymentGateway, GetPaymentGatewayByIdOutModel>();
        CreateMap<GetPaymentGatewayByIdOutModel, GetPaymentGatewayByIdResult>();

        #endregion

    }
}