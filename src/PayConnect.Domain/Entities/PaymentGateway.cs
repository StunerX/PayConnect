using PayConnect.Domain.Common;
using PayConnect.Domain.Exceptions;

namespace PayConnect.Domain.Entities;

public class PaymentGateway : Entity
{
    public PaymentGateway()
    {
    }
    
    public required string Name { get; init; }
    public required string BaseUrl { get; init; }
    public required string Image { get; init; }
    
    public static PaymentGateway Create(string name, string baseUrl, string image)
    {
        Validate(name, baseUrl, image);
        
        return new PaymentGateway
        {
            Id = Guid.NewGuid(),
            Name = name,
            BaseUrl = baseUrl,
            Image = image,
            CreatedAt = DateTime.UtcNow
        };
    }
    
    private static void Validate(string name, string baseUrl, string image)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");
        
        if (string.IsNullOrWhiteSpace(baseUrl))
            throw new DomainException("BaseUrl is required");
        
        if (string.IsNullOrWhiteSpace(image))
            throw new DomainException("Image is required");
    } 
    
}