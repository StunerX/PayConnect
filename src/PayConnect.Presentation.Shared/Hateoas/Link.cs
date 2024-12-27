namespace PayConnect.Presentation.Shared.Hateoas;

public class Link(string rel, string href, string method, string? type = null)
{
    public string Rel { get; set; } = rel;
    public string Href { get; set; } = href;
    public string Method { get; set; } = method;
    public string? Type { get; set; } = type;
}