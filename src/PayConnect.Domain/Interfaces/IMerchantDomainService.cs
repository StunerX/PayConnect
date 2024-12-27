namespace PayConnect.Domain.Interfaces;

public interface IMerchantDomainService
{
    Task VerifyMerchantExistsAsync(string document, CancellationToken cancellationToken = default);    
}