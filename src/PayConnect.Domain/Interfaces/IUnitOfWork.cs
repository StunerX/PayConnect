using PayConnect.Domain.Entities;

namespace PayConnect.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Game Entity repository
    /// </summary>
    IRepository<PaymentGateway> PaymentGatewayRepository
    {
        get;
    }
    
    Task CommitAsync();
}