using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PayConnect.Application.UseCases.Merchant.CreateMerchant;

namespace PayConnect.IntegrationTests.Application.UseCases.Merchant.CreateMerchant;

public class CreateMerchantUseCaseTests(CreateMerchantUseCaseTestsFixture fixture) : IClassFixture<CreateMerchantUseCaseTestsFixture>
{
    [Fact]
    public async Task CreateMerchantUseCase_WhenValidRequest_ShouldCreateMerchant()
    {
        var dbContext = fixture.CreateInMemoryDatabase();
        var unitOfWork = fixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.MerchantDomainService(unitOfWork);
        
        var mapper = fixture.CreateMapper();
        
        var paymentGatewayService = new PayConnect.Application.Services.MerchantService(domainService, unitOfWork, mapper);
        
        var useCase = new CreateMerchantUseCase(paymentGatewayService, mapper);
        var command = fixture.CreateCommand();
        
        var result = await useCase.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        
        var merchant = await dbContext.Merchant.FirstOrDefaultAsync(x => x.Id == result.Id);
        
        merchant.Should().NotBeNull();
        
        result.Name.Should().Be(merchant!.Name);
        result.LegalName.Should().Be(merchant.LegalName);
        result.Email.Should().Be(merchant.Email.Address);
        result.Phone.Should().Be(merchant.Phone);
        result.Document.Should().Be(merchant.Document.Id);
        result.Country.Should().Be(merchant.Country);
        result.Currency.Should().Be(merchant.Currency);
        result.WebhookUrl.Should().Be(merchant.WebhookUrl);
        result.NotificationEmail.Should().Be(merchant.NotificationEmail);
        result.CreatedAt.Should().Be(merchant.CreatedAt);

    }
}