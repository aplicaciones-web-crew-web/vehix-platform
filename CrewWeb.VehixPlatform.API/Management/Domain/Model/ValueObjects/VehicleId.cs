namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

/// <summary>
/// Represents an Identifier for a Vehicle. 
/// </summary>
/// <param name="Identifier">
///  The unique identifier for the Vehicle, represented as a GUID.
/// </param>

public record VehicleId(Guid Identifier)
{
    public VehicleId() : this(Guid.NewGuid()) {}
}