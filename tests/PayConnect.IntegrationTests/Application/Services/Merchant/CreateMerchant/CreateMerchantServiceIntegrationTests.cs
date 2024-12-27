using FluentAssertions;
using PayConnect.Application.Services;
using PayConnect.Domain.Services;

namespace PayConnect.IntegrationTests.Application.Services.Merchant.CreateMerchant;

public class CreateMerchantServiceIntegrationTests(CreateMerchantServiceIntegrationTestsFixture fixture)
    : IClassFixture<CreateMerchantServiceIntegrationTestsFixture>
{
    [Fact]
    public async Task CreateMerchantServiceIntegrationTests_ShouldCreateMerchant()
    {
        var dbContext = fixture.CreateInMemoryDatabase();
        var unitOfWork = fixture.CreateUnitOfWork(dbContext);
        var domainService = new MerchantDomainService(unitOfWork);
        
        var mapper = fixture.CreateMapper();

        var service = new MerchantService(domainService, unitOfWork, mapper);

        var inModel = fixture.CreateInModel();
        
        var outModel = await service.CreateAsync(inModel, CancellationToken.None);

        var entity = await unitOfWork.MerchantRepository.FirstAsync(x => x.Id == outModel.Id);

        entity.Should().NotBeNull();
        outModel.Should().NotBeNull();
        outModel.Id.Should().Be(entity!.Id);
        outModel.Name.Should().Be(entity.Name);
        outModel.LegalName.Should().Be(entity.LegalName);
        outModel.Email.Should().Be(entity.Email.Address);
        outModel.Phone.Should().Be(entity.Phone);
        outModel.Document.Should().Be(entity.Document.Id);
        outModel.Country.Should().Be(entity.Country);
        outModel.Currency.Should().Be(entity.Currency);
        outModel.WebhookUrl.Should().Be(entity.WebhookUrl);
        outModel.NotificationEmail.Should().Be(entity.NotificationEmail);
        outModel.CreatedAt.Should().Be(entity.CreatedAt);
    }
}