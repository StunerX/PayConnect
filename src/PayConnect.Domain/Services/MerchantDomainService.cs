using PayConnect.Domain.Exceptions;
using PayConnect.Domain.Interfaces;
using PayConnect.Domain.ValueObjects;

namespace PayConnect.Domain.Services;

public class MerchantDomainService(IUnitOfWork unitOfWork) : IMerchantDomainService
{
    public async Task VerifyMerchantExistsAsync(string document, CancellationToken cancellationToken = default)
    {
        var exists = await unitOfWork.MerchantRepository.AnyAsync(x => x.Document.Equals(Document.Create(document)));
        
        if (exists) throw new DomainException("Merchant already exists");
    }
}