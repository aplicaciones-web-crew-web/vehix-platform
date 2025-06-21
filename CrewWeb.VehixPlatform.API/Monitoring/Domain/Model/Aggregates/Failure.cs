using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure
{
    public int Id { get; }
    public string SuggestSolution { get; private set; }

    public BadPractice BadPractice { get; internal set; }
    public OdbError OdbError { get; internal set; }

    public int BadPracticeId { get; private set; }
    public int OdbErrorId { get; private set; }
    public int VehicleId { get; private set; }


    public Failure(){}
    public void AddBadPracticeToFailure(string descriptionBadPractice)
    {
        BadPractice = new BadPractice(descriptionBadPractice);
    }

    public void AddOdbErrorToFailure(string errorCode, string errorCodeTitle, string errorType)
    {
        OdbError = new OdbError(errorCode, errorCodeTitle, errorType);
    }

    public Failure( int obdErrorId, int badPracticeId, string suggestSolution)
    {
        OdbErrorId = obdErrorId;
        BadPracticeId = badPracticeId;
        SuggestSolution = suggestSolution;
    }

    public Failure(CreateFailureCommand command) : this(command.OdbErrorId, command.BadPracticeId, command.SuggestSolution)
    {
    }
}