using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Infrastructure.EntityFramework;

public class UnitOfWork(
    ApplicationDbContext dbContext,
    IRepository<PaymentGateway> paymentGatewayRepository,
    IRepository<Merchant> merchantRepository,
    IRepository<GatewayConfiguration> gatewayConfigurationRepository) : IUnitOfWork
{
    public IRepository<PaymentGateway> PaymentGatewayRepository { get; } = paymentGatewayRepository;
    public IRepository<Merchant> MerchantRepository { get; } = merchantRepository;
    public IRepository<GatewayConfiguration> GatewayConfigurationRepository { get; } = gatewayConfigurationRepository;

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