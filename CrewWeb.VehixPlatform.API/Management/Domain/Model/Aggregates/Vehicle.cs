using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Management.Domain.Model.Aggregates;

public partial class Vehicle
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public EBrand Brand { get; set; }
    public string Type { get; set; }
    public string Model { get; set; }
    public string Mileage { get; set; }
    public string Year { get; set; }
    public string ImageUrl { get; set; }


    public Vehicle(string description, string name, string brand, string model, string mileage, string year,
        string imageUrl)
    {
        Description = description;
        Name = name;
        Brand = brand;
        Model = model;
        Mileage = mileage;
        Year = year;
        ImageUrl = imageUrl;
    }

    public Vehicle(CreateVehicleCommand command) : this(command.Description, command.Name, command.Brand, command.Model,
        command.Mileage, command.Year, command.ImageUrl)
    {
    }
}