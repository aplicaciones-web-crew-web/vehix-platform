namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Commands;

public record ActivateSubscriptionCommand( 
    Guid SubscriptionId,
    DateTime StartDate,
    DateTime EndDate
);