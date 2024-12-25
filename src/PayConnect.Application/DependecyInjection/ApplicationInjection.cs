using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace PayConnect.Application.DependecyInjection;

public static class ApplicationInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        services.AddServices();
        services.AddScoped<HttpClient>();
        
        services.AddAutoMapper(typeof(ApplicationInjection).Assembly);
        
        return services;
    }
}