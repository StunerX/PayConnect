using AutoMapper;
using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;
using PayConnect.Application.Mapping;
using PayConnect.Application.UseCases.PaymentGateway.CreatePaymentGateway;

namespace PayConnect.IntegrationTests.Application.UseCases.PaymentGateway.CreatePaymentGateway;

[Collection(nameof(CreatePaymentGatewayUseCaseTestsIntegrationFixture))]
public class CreatePaymentGatewayUseCaseTests(CreatePaymentGatewayUseCaseTestsIntegrationFixture integrationFixture)
{
    [Fact]
    public async Task Should_Create_PaymentGateway()
    {
        var dbContext = integrationFixture.CreateInMemoryDatabase();
        var unitOfWork = integrationFixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.PaymentGatewayDomainService(unitOfWork);
        
        var mapper = integrationFixture.CreateMapper();
        
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork, domainService, mapper);
        
        var useCase = new CreatePaymentGatewayUseCase(paymentGatewayService, mapper);

        var request = new CreatePaymentGatewayCommand
        {
            Name = "Cielo",
            BaseUrl = "http://test.com",
            Image = "test.png"
        };
        
        var response = await useCase.Handle(request, CancellationToken.None);

        response.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();

    }
}