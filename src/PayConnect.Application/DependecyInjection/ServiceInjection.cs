using Microsoft.Extensions.DependencyInjection;
using PayConnect.Application.Interfaces;
using PayConnect.Application.Services;
using PayConnect.Domain.Interfaces;
using PayConnect.Domain.Services;

namespace PayConnect.Application.DependecyInjection;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        #region ApplicationServices
        services.AddScoped<IPaymentGatewayService, PaymentGatewayService>();
        #endregion

        #region DomainServices
        services.AddScoped<IPaymentGatewayDomainService, PaymentGatewayDomainService>();
        #endregion
        
        return services;
    }
}