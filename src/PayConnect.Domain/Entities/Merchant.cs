using PayConnect.Domain.Common;
using PayConnect.Domain.Exceptions;
using PayConnect.Domain.ValueObjects;

namespace PayConnect.Domain.Entities;

public class Merchant : Entity
{
    public required string Name { get; init; }
    public required string LegalName { get; init; }
    public required Email Email { get; init; }
    public required string Phone { get; init; }
    public required string Document { get; init; }
    public required string Country { get; init; }
    public required string Currency { get; init; }
    public string? WebhookUrl { get; private set; }
    public string? NotificationEmail { get; private set; }
    
    public static Merchant Create(string name, string legalName, string email, string phone, string document, string country, string currency)
    {
        Validate(name, legalName);
        
        return new Merchant
        {
            Id = Guid.NewGuid(),
            Name = name,
            LegalName = legalName,
            Email = Email.Create(email),
            Phone = phone,
            Document = document,
            Country = country,
            Currency = currency,
            CreatedAt = DateTime.UtcNow
        };
    }

    private static void Validate(string name, string legalName)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name is required");
        
        if (name.Length > 100) throw new DomainException("Name length must be less than or equal to 100 characters");
        
        if (string.IsNullOrWhiteSpace(legalName)) throw new DomainException("LegalName is required");
        
    }
}