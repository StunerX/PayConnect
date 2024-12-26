using Bogus;
using Bogus.Extensions.Brazil;
using PayConnect.Domain.Entities;

namespace PayConnect.UnitTests.Common;

public class MerchantBuilder
{
    private static readonly Faker Faker = new Faker("pt_BR");
    
    private string _name = Faker.Name.FullName();
    private string _legalName = Faker.Company.CompanyName();
    private string _email = Faker.Internet.Email();
    private string _phone = Faker.Phone.PhoneNumber();
    private string _document = Faker.Company.Cnpj();
    private string _country = Faker.Address.Country();
    private string _currency = Faker.Finance.Currency().Code;

    public MerchantBuilder WithName(string name) { _name = name; return this; }
    public MerchantBuilder WithLegalName(string legalName) { _legalName = legalName; return this; }
    public MerchantBuilder WithEmail(string email) { _email = email; return this; }
    public MerchantBuilder WithPhone(string phone) { _phone = phone; return this; }
    public MerchantBuilder WithDocument(string document) { _document = document; return this; }
    public MerchantBuilder WithCountry(string country) { _country = country; return this; }
    public MerchantBuilder WithCurrency(string currency) { _currency = currency; return this; }

    public Merchant Build()
    {
        return Merchant.Create(_name, _legalName, _email, _phone, _document, _country, _currency);
    }
}