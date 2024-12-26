using System.Net;
using System.Text.Json;
using FluentAssertions;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.GetById;

namespace PayConnect.E2ETests.Api.PaymentGateway.GetPaymentGatewayById;

[Collection(nameof(GetPaymentGatewayByIdApiTestsIntegrationFixture))]
public class GetPaymentGatewayByIdApiTests(GetPaymentGatewayByIdApiTestsIntegrationFixture integrationFixture)
{
    [Fact]
    public async Task GetPaymentGatewayById_ShouldReturnPaymentGateway()
    {
        // Arrange
        var dbContext = await integrationFixture.CreateE2EDatabaseAsync();
        var paymentGatewayEntity = Domain.Entities.PaymentGateway.Create("Test", "Test", "Test");

        await dbContext.PaymentGateway.AddAsync(paymentGatewayEntity);

        await dbContext.SaveChangesAsync();
       
        var client = integrationFixture.ApiClient;

        // Act
        var response = await client.GetAsync("/PaymentGateway/" + paymentGatewayEntity.Id);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        // Assert
        response.EnsureSuccessStatusCode();
        var contentString = await response.Content.ReadAsStringAsync();
        var paymentGateway = JsonSerializer.Deserialize<GetPaymentGatewayByIdResponse>(contentString, options);
        paymentGateway.Should().NotBeNull();
        paymentGateway!.Id.Should().Be(paymentGatewayEntity.Id);
        paymentGateway.Name.Should().Be(paymentGatewayEntity.Name);
        paymentGateway.BaseUrl.Should().Be(paymentGatewayEntity.BaseUrl);
        paymentGateway.Image.Should().Be(paymentGatewayEntity.Image);
        
    }
}