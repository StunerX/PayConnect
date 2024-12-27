using PayConnect.Domain.Common;
using PayConnect.Domain.Exceptions;

namespace PayConnect.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Id { get; }

    private Document(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new DomainException("Document id cannot be empty");
        
        Id = id;
    }
    
    public static Document Create(string id)
    {
        return new Document(id);
    }
    
    public override string ToString()
    {
        return Id;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id.ToLowerInvariant();
    }
   
}