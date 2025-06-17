namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.ValueObjects;
/// <summary>
/// Represents a unique identifier for a maintenance item in Crew Web Vehix Platform.
/// </summary>
/// <param name="Identifier">
/// The unique identifier for the maintenance item, represented as a GUID.
/// </param>
public record MaintenanceIdentifier(Guid Identifier)
{
    public MaintenanceIdentifier() : this(Guid.NewGuid()) { }
}