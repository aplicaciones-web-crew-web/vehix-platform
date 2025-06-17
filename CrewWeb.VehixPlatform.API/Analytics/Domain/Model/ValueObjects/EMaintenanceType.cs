namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.ValueObjects;

/// <summary>
/// Represents the types of maintenance that can be associated with a maintenance item.
/// </summary>
public enum EMaintenanceType
{
    /// <summary>
    /// Represents a maintenance item that predicts the future problems of a vehicle.
    /// </summary>
    ProblemForecasting,
    
    /// <summary>
    /// Represents a maintenance item that provides information about the vehicle's useful life.
    /// How long can the car be used under optimal conditions?
    /// </summary>
    CarUsefulLife,
    
    /// <summary>
    /// Represents a maintenance item that provides information about the main systems of the vehicle.
    /// How long can the car be used under optimal conditions?
    /// </summary>
    RapidDiagnosis,
    
    /// <summary>
    /// Represents a maintenance item that provides information about registered failures and repairs of the vehicle.
    /// </summary>
    RecentRepairs,
    
}