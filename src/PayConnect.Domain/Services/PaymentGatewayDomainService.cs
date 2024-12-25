using PayConnect.Domain.Exceptions;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Domain.Services;

public class PaymentGatewayDomainService(IUnitOfWork unitOfWork) : IPaymentGatewayDomainService
{
    public async Task VerifyPaymentGatewayExistsAsync(string name, string baseUrl)
    {
        var exists = await unitOfWork.PaymentGatewayRepository.AnyAsync(x =>
            x.Name.ToLower().Trim().Equals(name.ToLower().Trim()) &&
            x.BaseUrl.ToLower().Trim().Equals(baseUrl.ToLower().Trim()));
        
        if (exists) throw new DomainException("Payment gateway already exists");
        
    }
}