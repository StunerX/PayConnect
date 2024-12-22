using PayConnect.Tests.Shared;

namespace PayConnect.E2ETests.Common;

public class E2EPaymentWebApiBaseFixture : DatabaseFixture
{
    private CustomWebApplicationFactory<Program> WebApplicationFactory { get; } = new();
    
    public ApiClient ApiClient => CreateApiClient<Program>(WebApplicationFactory);
}