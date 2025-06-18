using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure
{
    public int Id { get; }
    public string SuggestSolution { get; private set; }
    public OdbError OdbError { get; private set; }
    public int OdbErrorId { get; private set; }
    public string OdbErrorCode { get; private set; }

    public Failure(int obdErrorId, string obdErrorCode, string suggestSolution)
    {
        SuggestSolution = suggestSolution;
        OdbErrorId = obdErrorId;
        OdbErrorCode = obdErrorCode;
    }

    public Failure(CreateFailureCommand command) : this(command.ObdErrorId, command.obdErrorCode, command.SugestSolution)
    {
        
    }
}