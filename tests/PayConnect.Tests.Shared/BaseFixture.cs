using AutoMapper;
using Bogus;
using Microsoft.EntityFrameworkCore;
using PayConnect.Application.Mapping;
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
    
    public ApiClient CreateApiClient<TStartup>(CustomWebApplicationFactory<TStartup> webFactory) where TStartup : class
    {
        var httpClient = webFactory.CreateClient();
        var apiClient = new ApiClient(httpClient);
        return apiClient;
    }
    
    public IMapper CreateMapper()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PaymentGatewayApplicationProfile>();
        });

        return configuration.CreateMapper();
    }
    
}