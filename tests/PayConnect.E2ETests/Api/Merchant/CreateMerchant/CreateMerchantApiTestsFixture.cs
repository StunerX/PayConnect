using PayConnect.E2ETests.Common;
using PayConnect.Payment.WebApi.Contracts.PaymentGateway.Merchant.Create;
using PayConnect.Tests.Shared.Builders;

namespace PayConnect.E2ETests.Api.Merchant.CreateMerchant;

public class CreateMerchantApiTestsFixture : E2EPaymentWebApiBaseIntegrationFixture
{
    private MerchantBuilder MerchantBuilder => new MerchantBuilder();
    
    public CreateMerchantRequest CreateRequest()
    {
        var merchant = MerchantBuilder.Build();

        return new CreateMerchantRequest
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