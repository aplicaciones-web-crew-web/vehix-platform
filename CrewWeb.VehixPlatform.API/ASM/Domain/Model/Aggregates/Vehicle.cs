using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;

public class Vehicle
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Mileage { get; set; }
    public int Year { get; set; }
    public string ImageUrl { get; set; }

    public Vehicle(int userId, string name, string brand, string model, int mileage, int year, string imageUrl)
    {
        UserId = userId;
        Name = name;
        Brand = brand;
        Model = model;
        Mileage = mileage;
        Year = year;
        ImageUrl = imageUrl;
        Description = $"{year} {brand} {model} - {mileage} km";
    }

    public Vehicle(CreateVehicleCommand command) : this(
        command.UserId,
        command.Name,
        command.Brand,
        command.Model,
        command.Mileage,
        command.Year,
        command.ImageUrl
    )
    {
    }
}