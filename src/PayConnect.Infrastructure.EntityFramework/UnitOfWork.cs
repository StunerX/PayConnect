using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Infrastructure.EntityFramework;

public class UnitOfWork(ApplicationDbContext dbContext, IRepository<PaymentGateway> paymentGatewayRepository) : IUnitOfWork
{
    public IRepository<PaymentGateway> PaymentGatewayRepository { get; } = paymentGatewayRepository;
    
    public async Task CommitAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Dispose object
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            dbContext.Dispose();
        }
    }
}