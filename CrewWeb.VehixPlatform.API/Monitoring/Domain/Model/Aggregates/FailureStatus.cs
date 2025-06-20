using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure : IState
{
    public EFailureStatus Status { get; protected set; }
    
    public void ChangeToFixed()
    {
        Status = EFailureStatus.Fixed;
    }

    public void ChangeToPending()
    {
        Status = EFailureStatus.Pending;
    }
}