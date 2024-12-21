using Bogus;
using Microsoft.EntityFrameworkCore;
using PayConnect.Domain.Entities;
using PayConnect.Infrastructure.EntityFramework;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Tests.Shared;

public abstract class BaseFixture
{
    protected Faker Faker { get; } = new("pt_BR");
    
    public ApplicationDbContext CreateInMemoryDatabase()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }
    
    public UnitOfWork CreateUnitOfWork(ApplicationDbContext dbContext)
    {
        var paymentGatewayRepository = new Repository<PaymentGateway>(dbContext);
        return new UnitOfWork(dbContext, paymentGatewayRepository);
    }
}