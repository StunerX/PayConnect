using System.Text.RegularExpressions;
using PayConnect.Domain.Common;
using PayConnect.Domain.Exceptions;

namespace PayConnect.Domain.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; }
    
    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new DomainException("Email address cannot be empty");
        
        if (!Regex.IsMatch(address, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            throw new DomainException("Invalid email format");
        
        Address = address;
    }
    
    public static Email Create(string address)
    {
        return new Email(address);
    }
    
    public override string ToString()
    {
        return Address;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address.ToLowerInvariant();
    }
}