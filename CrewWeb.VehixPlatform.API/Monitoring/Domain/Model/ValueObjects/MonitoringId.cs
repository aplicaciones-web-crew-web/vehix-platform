namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

public record MonitoringId(Guid Identifier)
{
    public MonitoringId() : this(Guid.NewGuid()) { }
}