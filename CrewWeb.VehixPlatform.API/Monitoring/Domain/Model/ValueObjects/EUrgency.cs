namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.ValueObjects;

/// <summary>
/// Represents the urgency level of a failure.
/// </summary>
public enum EUrgency
{
    /// <summary>
    /// Represents a critical failure that requires immediate attention.
    /// </summary>
    Critical,
    
    /// <summary>
    /// Represents a medium urgency failure that should be addressed promptly.
    /// </summary>
    Moderate,
    
    /// <summary>
    /// Represents a minor failure that may be resolved soon
    /// </summary>
    Mild
}