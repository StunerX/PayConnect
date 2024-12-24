using FluentAssertions;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Exceptions;

namespace PayConnect.UnitTests.Domain.Entities.PaymentGatewayTests;

public class PaymentGatewayTests
{
    [Fact]
    public void Create_ShouldReturnValidEntity_WhenAllFieldsAreCorrect()
    {
        var paymentGateway = PaymentGateway.Create("PicPay", "https://picpay.com", "image.png");
        
        paymentGateway.Id.Should().NotBe(Guid.Empty);
        paymentGateway.Name.Should().Be("PicPay");
        paymentGateway.BaseUrl.Should().Be("https://picpay.com");
        paymentGateway.Image.Should().Be("image.png");
        paymentGateway.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(50));
    }
    
    [Fact]
    public void Create_ShouldThrowException_WhenNameIsNullOrEmpty()
    {
        string? invalidName = null;
        const string validBaseUri = "https://api.stripe.com";
        var validImageUrl = "https://example.com/stripe-logo.png";

        var action = () => PaymentGateway.Create(invalidName, validBaseUri, validImageUrl);
        action.Should().Throw<DomainException>().WithMessage("Name is required");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_ShouldThrowException_WhenBaseUriIsInvalid(string baseUrl)
    {
        const string validName = "Stripe";
        var validImageUrl = "https://example.com/stripe-logo.png";

        var action = () => PaymentGateway.Create(validName, baseUrl, validImageUrl);

        action.Should().Throw<DomainException>().WithMessage("BaseUrl is required");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_ShouldThrowException_WhenImageUrlIsNullOrEmpty(string validImageUrl)
    {
        const string validName = "Stripe";
        var baseUrl = "https://api.stripe.com";

        var action = () => PaymentGateway.Create(validName, baseUrl, validImageUrl);

        action.Should().Throw<DomainException>().WithMessage("Image is required");

    }
}