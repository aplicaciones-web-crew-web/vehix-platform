namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public record FailureId(Guid Identifier)
{
    public FailureId() : this(Guid.NewGuid()) { }
}