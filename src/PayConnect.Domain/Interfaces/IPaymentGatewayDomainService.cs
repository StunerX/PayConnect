using PayConnect.Domain.Entities;

namespace PayConnect.Domain.Interfaces;

public interface IPaymentGatewayDomainService
{
    Task VerifyPaymentGatewayExistsAsync(string name, string baseUrl);
}