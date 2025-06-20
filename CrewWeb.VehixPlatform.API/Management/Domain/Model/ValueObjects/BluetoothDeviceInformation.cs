namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

/// <summary>
/// Represents a device information with a name and type.  
/// </summary>
/// <param name="Name">
/// The name of the device, which can be a string representation of the name.
/// </param>
/// <param name="Type">
/// The type of the bluetooth device, a string representation of the type.
/// </param>
public record BluetoothDeviceInformation(string Name, string Type);