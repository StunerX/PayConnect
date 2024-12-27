using PayConnect.Tests.Shared;

namespace PayConnect.E2ETests.Common;

public class E2EPaymentWebApiBaseIntegrationFixture : DatabaseIntegrationFixture, IAsyncLifetime
{
    private CustomWebApplicationFactory<Program> WebApplicationFactory { get; set; }
    
    public ApiClient ApiClient { get; set; }

    public async Task InitializeAsync()
    {
        await base.InitializeAsync();
        
        WebApplicationFactory = new CustomWebApplicationFactory<Program>(ConnectionString);
        ApiClient = new ApiClient(WebApplicationFactory.CreateClient());
    }
    
    public new async Task DisposeAsync()
    {
        await base.DisposeAsync();
    }
}