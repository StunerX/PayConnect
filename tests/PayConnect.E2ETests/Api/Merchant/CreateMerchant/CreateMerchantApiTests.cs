using System.Net;
using System.Text.Json;
using FluentAssertions;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;
using PayConnect.Payment.WebApi.Shared;

namespace PayConnect.E2ETests.Api.Merchant.CreateMerchant;

public class CreateMerchantApiTests(CreateMerchantApiTestsFixture fixture)
    : IClassFixture<CreateMerchantApiTestsFixture>
{
    [Fact]
    public async Task CreateMerchant_WithValidData_ShouldReturnCreated()
    {
        await fixture.CreateE2EDatabaseAsync();
        var request = fixture.CreateRequest();

        var client = fixture.ApiClient;

        var response = await client.PostAsync("/api/merchants", request);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var contentString = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var responseModel = JsonSerializer.Deserialize<CreateMerchantResponse>(contentString, options);

        responseModel.Should().NotBeNull();
        responseModel!.Id.Should().NotBeEmpty();
        responseModel.Name.Should().Be(request.Name);
        responseModel.LegalName.Should().Be(request.LegalName);
        responseModel.Email.Should().Be(request.Email);
        responseModel.Phone.Should().Be(request.Phone);
        responseModel.Document.Should().Be(request.Document);
        responseModel.Country.Should().Be(request.Country);
        responseModel.Currency.Should().Be(request.Currency);
        responseModel.CreatedAt.Should().NotBe(default);
    }

    [Fact]
    public async Task CreateMerchant_WithExistedData_ShouldReturnBadRequest()
    {
        var database = await fixture.CreateE2EDatabaseAsync();
        var request = fixture.CreateRequest();

        await database.Merchant.AddAsync(Domain.Entities.Merchant.Create(request.Name, request.LegalName, request.Email,
            request.Phone, request.Document, request.Country, request.Currency));

        await database.SaveChangesAsync();

        var client = fixture.ApiClient;

        var response = await client.PostAsync("/api/merchants", request);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var contentString = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var responseModel = JsonSerializer.Deserialize<ApiResponse<string>>(contentString, options);

        responseModel.Should().NotBeNull();
        responseModel!.HasError.Should().BeTrue();
        responseModel.Error.Should().Be("Merchant already exists");
    }
}