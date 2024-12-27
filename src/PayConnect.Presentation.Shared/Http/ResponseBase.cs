using System.Text.Json.Serialization;
using PayConnect.Presentation.Shared.Hateoas;

namespace PayConnect.Presentation.Shared.Http;

public abstract class ResponseBase
{
    [JsonPropertyName("_links")]
    public List<Link> Links { get; set; } = [];
    
    protected void AddLink(string rel, string href, string method, string? type = null)
    {
        Links.Add(new Link(rel, href, method, type));
    }
    
    public abstract void GenerateLinks();
}