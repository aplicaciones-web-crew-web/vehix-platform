using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;

public partial class Analytic
{
    public int Id;
    public int VehicleId { get; set; }
    public int Engine { get; set; }
    public int Transmission { get; set; }
    public int Brake { get; set; }
    public int Electrical { get; set; }
    public int Steering { get; set; }
    public int Suspension { get; set; }
    public int Fuel { get; set; }
    public int Refrigeration { get; set; }

    public Analytic(int vehicleId, int engine, int transmission, int brake, int electrical, int steering,
        int suspension, int fuel, int refrigeration)
    {
        VehicleId = vehicleId;
        Engine = engine;
        Transmission = transmission;
        Brake = brake;
        Electrical = electrical;
        Steering = steering;
        Suspension = suspension;
        Fuel = fuel;
        Refrigeration = refrigeration;
    }

    public Analytic(CreateAnalyticCommand command) : this(
        command.VehicleId,
        command.Engine,
        command.Transmission,
        command.Brake,
        command.Electrical,
        command.Steering,
        command.Suspension,
        command.Fuel,
        command.Refrigeration
    )
    {
    }
}