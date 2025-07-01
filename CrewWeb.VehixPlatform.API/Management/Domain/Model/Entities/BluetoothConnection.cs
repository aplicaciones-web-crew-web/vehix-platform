using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;

public class BluetoothConnection(BluetoothDeviceInformation deviceInfo)
{
    public int Id { get; }
    public BluetoothDeviceInformation DeviceInformation { get; private set; } = deviceInfo;
    public EBluetoothStatus Status { get; private set; } = EBluetoothStatus.Unknown;

    public void Connect() => Status = EBluetoothStatus.Connected;
    public void Disconnect() => Status = EBluetoothStatus.Disconnected;
    public void Searching() => Status = EBluetoothStatus.Searching;
}