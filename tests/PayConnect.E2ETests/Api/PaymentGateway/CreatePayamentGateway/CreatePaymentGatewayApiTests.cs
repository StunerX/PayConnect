using System.Net;
using System.Text.Json;
using FluentAssertions;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

namespace PayConnect.E2ETests.Api.PaymentGateway.CreatePayamentGateway;

[Collection(nameof(CreatePaymentGatewayApiTestsIntegrationFixture))]
public class CreatePaymentGatewayApiTests(CreatePaymentGatewayApiTestsIntegrationFixture integrationFixture)
{
    [Fact]
    public async Task Post_PaymentGateway_ShouldReturnCreated()
    {
        await integrationFixture.CreateE2EDatabaseAsync();
        var request = new CreatePaymentGatewayRequest
        {
            Name = "Test",
            BaseUrl = "Test",
            Image = "Test",
        };

        var client = integrationFixture.ApiClient;

        var response = await client.PostAsync("/PaymentGateway", request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        var contentString = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var responseModel = JsonSerializer.Deserialize<CreatePaymentGatewayResult>(contentString, options);

        responseModel.Should().NotBeNull();
        responseModel!.Id.Should().NotBeEmpty();
    }
}