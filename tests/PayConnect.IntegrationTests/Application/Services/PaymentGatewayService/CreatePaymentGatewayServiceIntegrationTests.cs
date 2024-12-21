using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;

namespace PayConnect.IntegrationTests.Application.Services.PaymentGatewayService;

[Collection(nameof(CreatePaymentGatewayServiceIntegrationTestsFixture))]
public class CreatePaymentGatewayServiceIntegrationTests(CreatePaymentGatewayServiceIntegrationTestsFixture fixture)
{
    [Fact]
    public async Task Should_Create_PaymentGateway()
    {
        var dbContext = fixture.CreateInMemoryDatabase();
        var unitOfWork = fixture.CreateUnitOfWork(dbContext);
        
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork);

        var inModel = new CreatePaymentGatewayInModel
        {
            Name = "Cielo",
            BaseUrl = "http://test.com",
            Image = "test.png"
        };
        
        var outModel = await paymentGatewayService.CreateAsync(inModel, CancellationToken.None);

        var paymentGateway = await unitOfWork.PaymentGatewayRepository.FirstAsync(x => x.Id == outModel.Id);
       
        paymentGateway.Should().NotBeNull();
        paymentGateway!.Name.Should().Be("Cielo");
        paymentGateway.BaseUrl.Should().Be("http://test.com");
        paymentGateway.Image.Should().Be("test.png");
    }
}