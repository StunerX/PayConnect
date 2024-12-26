using FluentAssertions;
using PayConnect.Domain.Entities;
using PayConnect.Domain.Exceptions;

namespace PayConnect.UnitTests.Domain.Entities.MerchantTests;

public class MerchantTests(MerchantTestsFixture fixture) : IClassFixture<MerchantTestsFixture>
{
    [Fact]
    public void Create_ShouldReturnValidEntity_WhenAllFieldsAreCorrect()
    {
        var name = fixture.Faker.Name.FullName();
        var legalName = fixture.Faker.Company.CompanyName();
        var email = fixture.Faker.Internet.Email();
        var phone = fixture.Faker.Phone.PhoneNumber();
        var document = fixture.Faker.Random.String2(14);
        var country = fixture.Faker.Address.Country();
        var currency = fixture.Faker.Finance.Currency().Code;
        
        var merchant = Merchant.Create(name, legalName, email, phone, document, country, currency);
        
        merchant.Id.Should().NotBe(Guid.Empty);
        merchant.Name.Should().Be(name);
        merchant.LegalName.Should().Be(legalName);
        merchant.Email.Should().Be(email);
        merchant.Phone.Should().Be(phone);
        merchant.Document.Should().Be(document);
        merchant.Country.Should().Be(country);
        merchant.Currency.Should().Be(currency);
        merchant.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(50));
    }
    
    [Fact]
    public void Create_ShouldThrowException_WhenNameIsNullOrEmpty()
    {
        string? invalidName = null;
        var validLegalName = fixture.Faker.Company.CompanyName();
        var validEmail = fixture.Faker.Internet.Email();
        var validPhone = fixture.Faker.Phone.PhoneNumber();
        var validDocument = fixture.Faker.Random.String2(14);
        var validCountry = fixture.Faker.Address.Country();
        var validCurrency = fixture.Faker.Finance.Currency().Code;

        var action = () => Merchant.Create(invalidName!, validLegalName, validEmail, validPhone, validDocument, validCountry, validCurrency);
        action.Should().Throw<DomainException>().WithMessage("Name is required");
    }
}