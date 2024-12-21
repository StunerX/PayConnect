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
    
   
}