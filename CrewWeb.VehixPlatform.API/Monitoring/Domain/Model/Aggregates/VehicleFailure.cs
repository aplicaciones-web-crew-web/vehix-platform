using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public class VehicleFailure
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int FailureId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public VehicleFailure(int vehicleId, int failureId, DateTime date, string status)
    {
        VehicleId = vehicleId;
        FailureId = failureId;
        Date = date;
        Status = status;
    }

    public VehicleFailure(CreateVehicleFailureCommand command) : this(command.VehicleId, command.FailureId,
        command.Date, command.Status)
    {
    }

    public VehicleFailure(UpdateVehicleFailureCommand command) : this(command.VehicleId, command.FailureId,
        command.Date, command.Status)
    {
    }
    
}