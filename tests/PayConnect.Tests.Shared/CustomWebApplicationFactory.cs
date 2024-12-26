using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Tests.Shared;

public class CustomWebApplicationFactory<TStartup>(string connectionString) : WebApplicationFactory<TStartup>
    where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, configBuilder) =>
        {
            Console.WriteLine($"Using connection string: {connectionString}");
            
            configBuilder.AddInMemoryCollection([
                new KeyValuePair<string, string?>("ConnectionStrings:DefaultConnection", connectionString)
            ]);
        });

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
        });
        
        base.ConfigureWebHost(builder);
    }
}
