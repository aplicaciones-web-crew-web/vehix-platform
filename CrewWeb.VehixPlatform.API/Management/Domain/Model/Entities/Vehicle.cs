using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;

public class Vehicle
{
    public int Id { get; }
    
    public VehicleId VehicleIdentifier { get; private set; } = new();
    public UserId OwnerId { get; private set; }
    public VehicleSpecs Specs { get; private set; }
    public EFuelType FuelType { get; private set; }
    public Plate Plate { get; private set; }
    public Mileage Mileage { get; private set; }

    public Vehicle(UserId ownerId, VehicleSpecs specs, EFuelType fuelType, Plate plate, Mileage mileage)
    {
        OwnerId = ownerId;
        Specs = specs;
        FuelType = fuelType;
        Plate = plate;
        Mileage = mileage;
        VehicleIdentifier = new VehicleId();
    }
    
    public Vehicle() : this( 
        new UserId(0),
        new VehicleSpecs("Unknown", "Unknown", DateTime.Now.Year),
        EFuelType.None, 
        new Plate("XXXX-0000"), 
        new Mileage(0)
    ) {}

    public Vehicle(CreateVehicleCommand command) : this(
        new UserId(command.OwnerId), 
        new VehicleSpecs(command.Model, command.Brand, command.Year), 
        command.FuelType, 
        new Plate(command.Plate), 
        new Mileage(command.Mileage)
    ) {}
}