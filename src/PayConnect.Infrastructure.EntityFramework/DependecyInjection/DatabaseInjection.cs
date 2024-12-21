using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Infrastructure.EntityFramework.DependecyInjection;

public static class DatabaseInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException(connectionString, $"Variavel de ambiente {nameof(connectionString)} não foi encontrada");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies().UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        return services;
    }
}