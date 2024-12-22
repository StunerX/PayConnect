using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PayConnect.Tests.Shared;

public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("E2ETest");
        // builder.ConfigureServices(services =>
        // {
        //     var servicesProvider = services.BuildServiceProvider();
        //     using var scope = servicesProvider.CreateScope();
        //     var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //     dbContext.Database.EnsureDeleted();
        //     dbContext.Database.EnsureCreated();
        // });

        base.ConfigureWebHost(builder);
    }
}