namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

public record VehicleIdentifier(Guid Identifier)
{
    public VehicleIdentifier() : this(Guid.NewGuid()) {}
}