using PayConnect.Domain.Common;
using PayConnect.Domain.Exceptions;

namespace PayConnect.Domain.Entities;

public class Merchant : Entity
{
    public required string Name { get; init; }
    public required string LegalName { get; init; }
    public required string Email { get; init; }
    public required string Phone { get; init; }
    public required string Document { get; init; }
    public required string Country { get; init; }
    public required string Currency { get; init; }
    public string? WebhookUrl { get; private set; }
    public string? NotificationEmail { get; private set; }
    
    public static Merchant Create(string name, string legalName, string email, string phone, string document, string country, string currency)
    {
        Validate(name);
        
        return new Merchant
        {
            Id = Guid.NewGuid(),
            Name = name,
            LegalName = legalName,
            Email = email,
            Phone = phone,
            Document = document,
            Country = country,
            Currency = currency,
            CreatedAt = DateTime.UtcNow
        };
    }

    private static void Validate(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name is required");
    }
}