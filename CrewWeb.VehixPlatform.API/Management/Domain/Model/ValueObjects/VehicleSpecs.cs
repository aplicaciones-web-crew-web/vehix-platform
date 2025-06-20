namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;
/// <summary>
/// Represents the specifications of a vehicle. 
/// </summary>
/// <param name="Model">
/// The model of the vehicle, which can be a string representation of the model.
/// </param>
/// <param name="Brand">
/// The brand of the vehicle, which can be a string representation of the brand.
/// </param>
/// <param name="Year">
/// The year of the vehicle, which can be an int representation of the year.
/// </param>
public record VehicleSpecs(string Model, string Brand, int Year);