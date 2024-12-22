using System.Text.Json;
using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

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
            Data = new CreatePaymentGatewayInModel
            {
                Name = "Test",
                BaseUrl = "Test",
                Image = "Test",
            }
        };

        var client = fixture.ApiClient;

        var response = await client.PostAsync("/PaymentGateway", request);
        response.EnsureSuccessStatusCode();
        
        var contentString = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var responseModel = JsonSerializer.Deserialize<CreatePaymentGatewayResponse>(contentString, options);

        responseModel!.Data.Should().NotBeNull();
        responseModel.Data!.Id.Should().NotBeEmpty();
        responseModel.Error.Should().BeNull();
        responseModel.HasError.Should().BeFalse();
        
    }
}