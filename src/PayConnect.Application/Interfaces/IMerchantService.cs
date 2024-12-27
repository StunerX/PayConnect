using PayConnect.Application.Dto.Merchant.Create.Input;
using PayConnect.Application.Dto.Merchant.Create.Output;

namespace PayConnect.Application.Interfaces;

public interface IMerchantService
{
    Task<CreateMerchantOutModel> CreateAsync(CreateMerchantInModel model, CancellationToken cancellationToken = default);
}