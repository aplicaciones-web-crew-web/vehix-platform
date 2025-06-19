using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure
{
    public int Id { get; }
    public string SuggestSolution { get; private set; }

    public BadPractice BadPractice { get; private set; }
    public OdbError OdbError { get; private set; }

    public int BadPracticeId { get; private set; }
    public int OdbErrorId { get; private set; }
    public int VehicleId { get; private set; }


    public Failure(int vehicleId, int obdErrorId, int badPracticeId, string suggestSolution)
    {
        VehicleId = vehicleId;
        OdbErrorId = obdErrorId;
        BadPracticeId = badPracticeId;
        SuggestSolution = suggestSolution;
    }

    public Failure(CreateFailureCommand command) : this(command.VehicleId, command.OdbErrorId, command.BadPracticeId,
        command.SuggestSolution)
    {
    }
}