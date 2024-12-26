using FluentAssertions;
using PayConnect.Application.Dto.PaymentGateway.Create.Input;

namespace PayConnect.IntegrationTests.Application.Services.PaymentGatewayService;

[Collection(nameof(CreatePaymentGatewayServiceIntegrationTestsIntegrationFixture))]
public class CreatePaymentGatewayServiceIntegrationTests(CreatePaymentGatewayServiceIntegrationTestsIntegrationFixture integrationFixture)
{
    [Fact]
    public async Task Should_Create_PaymentGateway()
    {
        var dbContext = integrationFixture.CreateInMemoryDatabase();
        var unitOfWork = integrationFixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.PaymentGatewayDomainService(unitOfWork);
        
        var mapper = integrationFixture.CreateMapper();

        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork, domainService, mapper);

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
    
    [Fact]
    public async Task Should_Throw_DomainException_When_PaymentGateway_Exists()
    {
        var dbContext = integrationFixture.CreateInMemoryDatabase();
        var unitOfWork = integrationFixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.PaymentGatewayDomainService(unitOfWork);
        
        var mapper = integrationFixture.CreateMapper();
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork, domainService, mapper);

        var inModel = new CreatePaymentGatewayInModel
        {
            Name = "Cielo",
            BaseUrl = "http://test.com",
            Image = "test.png"
        };
        
        await paymentGatewayService.CreateAsync(inModel, CancellationToken.None);

        var act = async () => await paymentGatewayService.CreateAsync(inModel, CancellationToken.None);
        
        await act.Should().ThrowAsync<Domain.Exceptions.DomainException>().WithMessage("Payment gateway already exists");
    }
    
    [Fact]
    public async Task Should_Get_PaymentGateway_By_Id()
    {
        var dbContext = integrationFixture.CreateInMemoryDatabase();
        var unitOfWork = integrationFixture.CreateUnitOfWork(dbContext);
        var domainService = new PayConnect.Domain.Services.PaymentGatewayDomainService(unitOfWork);
        
        var mapper = integrationFixture.CreateMapper();
        var paymentGatewayService = new PayConnect.Application.Services.PaymentGatewayService(unitOfWork, domainService, mapper);

        var inModel = new CreatePaymentGatewayInModel
        {
            Name = "Cielo",
            BaseUrl = "http://test.com",
            Image = "test.png"
        };
        
        var outModel = await paymentGatewayService.CreateAsync(inModel, CancellationToken.None);

        var result = await paymentGatewayService.GetByIdAsync(outModel.Id, CancellationToken.None);
        
        result.Should().NotBeNull();
        result!.Id.Should().Be(outModel.Id);
        result.Name.Should().Be("Cielo");
        result.BaseUrl.Should().Be("http://test.com");
        result.Image.Should().Be("test.png");
    }
}