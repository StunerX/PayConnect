using PayConnect.Domain.Interfaces;

namespace PayConnect.Domain.Services;

public class MerchantDomainService(IUnitOfWork unitOfWork) : IMerchantDomainService
{
    public async Task VerifyMerchantExistsAsync(string document, CancellationToken cancellationToken = default)
    {
       
    }
}