using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.ASM.Domain.Model.Events;

public class VehicleCreatedEvent(
    int userId,
    string description,
    string name,
    string brand,
    string model,
    int mileage,
    int year,
    string imageUrl
) : IEvent
{
    public int UserId { get; } = userId;
    public string Description { get; } = description;
    public string Name { get; } = name;
    public string Brand { get; } = brand;
    public string Model { get; } = model;
    public int Mileage { get; } = mileage;
    public int Year { get; } = year;
    public string ImageUrl { get; } = imageUrl;
}