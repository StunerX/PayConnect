using PayConnect.Application.UseCases.Merchant.CreateMerchant;
using PayConnect.Tests.Shared;
using PayConnect.Tests.Shared.Builders;

namespace PayConnect.IntegrationTests.Application.UseCases.Merchant.CreateMerchant;

public class CreateMerchantUseCaseTestsFixture : BaseIntegrationFixture
{
    private MerchantBuilder MerchantBuilder => new MerchantBuilder();
    
    public CreateMerchantCommand CreateCommand()
    {
        var merchant = MerchantBuilder.Build();

        return new CreateMerchantCommand
        {
            Name = merchant.Name,
            LegalName = merchant.LegalName,
            Email = merchant.Email.Address,
            Phone = merchant.Phone,
            Document = merchant.Document.Id,
            Country = merchant.Country,
            Currency = merchant.Currency
        };
    }
}