namespace PayConnect.Payment.WebApi.DependecyInjection;

public static class PresentationInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PresentationInjection).Assembly);

        return services;
    }
}