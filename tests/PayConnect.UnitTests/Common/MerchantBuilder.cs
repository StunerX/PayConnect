using PayConnect.Domain.Entities;

namespace PayConnect.UnitTests.Common;

public class MerchantBuilder
{
    private string _name = "Default Name";
    private string _legalName = "Default Legal Name";
    private string _email = "default@example.com";
    private string _phone = "123456789";
    private string _document = "12345678901234";
    private string _country = "Default Country";
    private string _currency = "USD";

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