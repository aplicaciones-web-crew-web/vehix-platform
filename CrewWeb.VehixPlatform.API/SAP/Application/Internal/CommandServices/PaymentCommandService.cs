using Cortex.Mediator;
using Cortex.Mediator.Infrastructure;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.CommandServices;

/// <summary>
/// This class implements the command service for handling payment-related commands.
/// </summary>
/// <param name="paymentRepository"></param>
/// <param name="unitOfWork"></param>
/// <param name="domainEventPublisher"></param>
public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher) : IPaymentCommandService
{
    public Task<Payment?> Handle(CreatePaymentCommand command)
    {
        
        if (!Enum.IsDefined(typeof(EPaymentStatus), command.Status))
        {
            throw new GeneralException("The Payment Status must be a valid value, as 'Completed', 'Pending'",
                "VALIDATION");
        }
        
        
        
        

        throw new NotImplementedException();
    }
}