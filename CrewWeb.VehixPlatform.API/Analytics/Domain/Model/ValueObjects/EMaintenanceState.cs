namespace CrewWeb.VehixPlatform.API.Analytics.Domain.Model.ValueObjects;

/// <summary>
/// Represents the various analytics maintenance statuses of a content item.
/// Example: A maintenance item can be accessible or inaccessible. This
/// needs a vehicle scanned, else it is inaccessible.
/// </summary>
public enum EMaintenanceState
{
    /// <summary>
    /// The maintenance item is accessible.
    /// </summary>
    Accessible,

    /// <summary>
    /// The maintenance item is inaccessible.
    /// </summary>
    Inaccessible,
}