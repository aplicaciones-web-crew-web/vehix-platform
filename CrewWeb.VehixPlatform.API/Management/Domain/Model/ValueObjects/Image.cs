namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

public record Image
{
    public string Url { get; init; } = string.Empty;

    public Image(string url)
    {
        Url = url;
    }

    public Image() : this(string.Empty)
    {
    }
}