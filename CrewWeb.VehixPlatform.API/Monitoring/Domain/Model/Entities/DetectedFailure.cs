using CrewWeb.VehixPlatform.API.Monitoring.Domain.ValueObjects;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;

public class DetectedFailure(EFailureType Type, EFailureUrgencyLevel Level)
{
    public int Id { get; }
    public EFailureType Type { get; private set; } = Type;
    public EFailureUrgencyLevel UrgencyLevel { get; private set; } = Level;
    
}