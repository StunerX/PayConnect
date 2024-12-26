using PayConnect.Domain.Exceptions;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Domain.Services;

public class MerchantDomainService(IUnitOfWork unitOfWork) : IMerchantDomainService
{
    public async Task VerifyMerchantExistsAsync(string document, CancellationToken cancellationToken = default)
    {
        var exists = await unitOfWork.MerchantRepository.AnyAsync(x => x.Document.Trim().ToLower().Equals(document.Trim().ToLower()));
        
        if (exists) throw new DomainException("Merchant already exists");
    }
}