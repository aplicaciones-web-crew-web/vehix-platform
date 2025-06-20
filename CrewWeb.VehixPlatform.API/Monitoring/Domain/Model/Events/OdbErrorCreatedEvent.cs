using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;

public class OdbErrorCreatedEvent(string errorCode, string errorCodeTitle, string errorCodeType) : IEvent
{
    public string ErrorCode { get; } = errorCode;
    public string ErrorCodeTitle { get; } = errorCodeTitle;
    public string ErrorCodeType { get; } = errorCodeType;
}