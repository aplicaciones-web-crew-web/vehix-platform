using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;

public partial class Failure : IUrgency
{
    public EFailureUrgency Urgency { get; protected set; }
    
    public void ChangeToCritical()
    {
        Urgency = EFailureUrgency.Critical;
    }

    public void ChangeToModerate()
    {
        Urgency = EFailureUrgency.Moderate;
    }

    public void ChangeToMild()
    {
        Urgency = EFailureUrgency.Mild;
    }
}