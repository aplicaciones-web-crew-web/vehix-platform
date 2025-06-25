using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;

public partial class UserVehicleProfile
{
    public int Id { get; }
    public UserId UserId { get; private set; }
    public ESubscriptionType Subscription { get; private set; }
    public List<Vehicle> Vehicles { get; private set; } = [];
    public List<BluetoothConnection> BluetoothConnections { get; private set; } = [];
    
    public UserVehicleProfile(UserId userId, ESubscriptionType subscription)
    {
        UserId = userId;
        Subscription = subscription;
    }

    public void Handle(CreateVehicleCommand command)
    {
        if (command.Mileage < 0)
            throw new ArgumentException("Mileage cannot be negative");
        var vehicle = new Vehicle(
            new UserId(command.OwnerId),
            new VehicleSpecs(command.Model, command.Brand, command.Year),
            command.FuelType,
            new Plate(command.Plate),
            new Mileage(command.Mileage)
        );
    }

    public void Handle(SetDefaultVehicleCommand command)
    {
        var vehicleToSetDefault = Vehicles.FirstOrDefault( v => v.Id == command.VehicleId);
        if(vehicleToSetDefault is null)
            throw new InvalidOperationException("No vehicle found");
    }

}