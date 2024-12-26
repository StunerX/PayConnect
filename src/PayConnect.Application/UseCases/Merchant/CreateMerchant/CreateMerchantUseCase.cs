using AutoMapper;
using MediatR;
using PayConnect.Application.Dto.Merchant.Create.Input;
using PayConnect.Application.Interfaces;

namespace PayConnect.Application.UseCases.Merchant.CreateMerchant;

public class CreateMerchantUseCase(IMerchantService service, IMapper mapper) : IRequestHandler<CreateMerchantCommand, CreateMerchantResult>
{
    public async Task<CreateMerchantResult> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var outModel = await service.CreateAsync(mapper.Map<CreateMerchantInModel>(request), cancellationToken);
        return mapper.Map<CreateMerchantResult>(outModel);
    }
}