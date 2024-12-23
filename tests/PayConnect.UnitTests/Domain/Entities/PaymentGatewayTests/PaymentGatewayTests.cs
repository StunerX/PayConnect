using FluentAssertions;
using PayConnect.Domain.Entities;

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

        var exception = Assert.Throws<ArgumentException>(() => PaymentGateway.Create(invalidName, validBaseUri, validImageUrl));

        exception.Message.Should().Be("Name is required (Parameter 'name')");
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_ShouldThrowException_WhenBaseUriIsInvalid(string baseUrl)
    {
        // Arrange
        const string validName = "Stripe";
        var validImageUrl = "https://example.com/stripe-logo.png";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            PaymentGateway.Create(validName, baseUrl, validImageUrl));

        exception.Message.Should().Be("BaseUrl is required (Parameter 'baseUrl')");
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
        
        action.Should()
            .Throw<ArgumentException>()
            .WithMessage("Image is required (Parameter 'Image')")
            .And.ParamName.Should().Be("image");
        
    }
}