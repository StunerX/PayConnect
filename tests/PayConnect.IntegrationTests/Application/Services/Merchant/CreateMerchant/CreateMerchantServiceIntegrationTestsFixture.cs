using PayConnect.Application.Dto.Merchant.Create.Input;
using PayConnect.Tests.Shared;
using PayConnect.Tests.Shared.Builders;

namespace PayConnect.IntegrationTests.Application.Services.Merchant.CreateMerchant;

public class CreateMerchantServiceIntegrationTestsFixture : BaseIntegrationFixture
{
    private MerchantBuilder MerchantBuilder => new MerchantBuilder();
    
    public CreateMerchantInModel CreateInModel()
    {
        var merchant = MerchantBuilder.Build();

        return new CreateMerchantInModel
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