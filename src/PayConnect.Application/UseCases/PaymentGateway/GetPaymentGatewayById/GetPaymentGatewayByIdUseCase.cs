using AutoMapper;
using MediatR;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

public class GetPaymentGatewayByIdUseCase(IPaymentGatewayService service, IMapper mapper) : IRequestHandler<GetPaymentGatewayByIdQuery, GetPaymentGatewayByIdResult>
{
    public async Task<GetPaymentGatewayByIdResult> Handle(GetPaymentGatewayByIdQuery request, CancellationToken cancellationToken)
    {
        var outModel = await service.GetByIdAsync(request.Id, cancellationToken);
        return mapper.Map<GetPaymentGatewayByIdResult>(outModel);
    }
}