namespace PayConnect.Presentation.Shared.Hateoas;

public static class LinkTemplate
{
    public static Link CreateLink(string rel, string pathTemplate, object? routeValues = null, string method = "GET", string type = "application/json")
    {
        var href = GenerateHref(pathTemplate, routeValues);

        return new Link(rel, href, method)
        {
            Type = type
        };
    }

    private static string GenerateHref(string pathTemplate, object? routeValues)
    {
        if (routeValues == null)
            return pathTemplate; 

        foreach (var prop in routeValues.GetType().GetProperties())
        {
            var placeholder = "{" + prop.Name + "}";
            var value = prop.GetValue(routeValues, null);
            pathTemplate = pathTemplate.Replace(placeholder, value?.ToString() ?? string.Empty);
        }

        return pathTemplate;
    }
}