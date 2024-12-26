using PayConnect.Domain.Entities;

namespace PayConnect.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Payment Gateway Entity repository
    /// </summary>
    IRepository<PaymentGateway> PaymentGatewayRepository
    {
        get;
    }
    
    /// <summary>
    /// Merchant Entity repository
    /// </summary>
    IRepository<Merchant> MerchantRepository
    {
        get;
    }
    
    Task CommitAsync();
}