using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

namespace PayConnect.IntegrationTests.Application.UseCases.PaymentGateway.CreatePaymentGateway;

[Collection(nameof(CreatePaymentGatewayUseCaseTestsFixture))]
public class CreatePaymentGatewayUseCaseTests(CreatePaymentGatewayUseCaseTestsFixture fixture)
{
    [Fact]
    public async Task Should_Create_PaymentGateway()
    {
        var dbContext = fixture.CreateInMemoryDatabase();
        var unitOfWork = fixture.CreateUnitOfWork(dbContext);
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork);
        
        var useCase = new CreatePaymentGatewayUseCase(paymentGatewayService);

        var request = new CreatePaymentGatewayRequest
        {
            Data = new CreatePaymentGatewayInModel
            {
                Name = "Cielo",
                BaseUrl = "http://test.com",
                Image = "test.png"
            }
        };
        
        var response = await useCase.Handle(request, CancellationToken.None);

        response.HasError.Should().BeFalse();
        response.Error.Should().BeNull();
        response.Data.Should().NotBeNull();
        response.Data!.Id.Should().NotBeEmpty();

    }
}