using Microsoft.Extensions.DependencyInjection;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Interfaces;

namespace PayConnect.Infrastructure.EntityFramework.DependecyInjection;

public static class RepositoryInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<PaymentGateway>, Repository<PaymentGateway>>();
        services.AddScoped<IRepository<Merchant>, Repository<Merchant>>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}