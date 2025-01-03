using FluentAssertions;
using PayConnect.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

namespace PayConnect.IntegrationTests.Application.UseCases.PaymentGateway.GetPaymentGatewayById;

[Collection(nameof(GetPaymentGatewayByIdUseCaseTestsIntegrationFixture))]
public class GetPaymentGatewayByIdUseCaseTests(GetPaymentGatewayByIdUseCaseTestsIntegrationFixture integrationFixture)
{
    [Fact]
    public async Task Should_Return_PaymentGateway()
    {
        var dbContext = integrationFixture.CreateInMemoryDatabase();
        var unitOfWork = integrationFixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.PaymentGatewayDomainService(unitOfWork);
        
        var mapper = integrationFixture.CreateMapper();
        
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork, domainService, mapper);
        
        var useCase = new GetPaymentGatewayByIdUseCase(paymentGatewayService, mapper);

        var paymentGateway = new PayConnect.Domain.Entities.PaymentGateway
        {
            Name = "Cielo",
            BaseUrl = "http://test.com",
            Image = "test.png"
        };
        
        await unitOfWork.PaymentGatewayRepository.AddAsync(paymentGateway);
        await unitOfWork.CommitAsync();

        var request = new GetPaymentGatewayByIdQuery
        {
            Id = paymentGateway.Id
        };
        
        var response = await useCase.Handle(request, CancellationToken.None);

        response.Should().NotBeNull();
        response.Id.Should().Be(paymentGateway.Id);
        response.Name.Should().Be(paymentGateway.Name);
        response.BaseUrl.Should().Be(paymentGateway.BaseUrl);
        response.Image.Should().Be(paymentGateway.Image);
    }
    
}