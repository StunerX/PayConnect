using Microsoft.Extensions.DependencyInjection;
using PayConnect.Application.Interfaces;
using PayConnect.Application.Services;

namespace PayConnect.Application.DependecyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentGatewayService, PaymentGatewayService>();
        return services;
    }
}