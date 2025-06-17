namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public record VehixFailureIdentifier(Guid Identifier)
{
    public VehixFailureIdentifier() : this(Guid.NewGuid()) { }
}