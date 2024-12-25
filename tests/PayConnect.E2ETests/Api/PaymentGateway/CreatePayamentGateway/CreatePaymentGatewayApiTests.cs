using System.Net;
using System.Text.Json;
using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Create;

namespace PayConnect.E2ETests.Api.PaymentGateway.CreatePayamentGateway;

[Collection(nameof(CreatePaymentGatewayApiTestsFixture))]
public class CreatePaymentGatewayApiTests(CreatePaymentGatewayApiTestsFixture fixture)
{
    [Fact]
    public async Task Post_PaymentGateway_ShouldReturnCreated()
    {
        await fixture.CreateE2EDatabaseAsync();

        var request = new CreatePaymentGatewayRequest
        {
            Name = "Test",
            BaseUrl = "Test",
            Image = "Test",
        };

        var client = fixture.ApiClient;

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