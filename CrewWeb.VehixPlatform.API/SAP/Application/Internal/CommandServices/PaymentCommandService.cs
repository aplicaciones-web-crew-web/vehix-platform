using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using IUnitOfWork = CrewWeb.VehixPlatform.API.Shared.Domain.Repositories.IUnitOfWork;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.CommandServices;

/// <summary>
/// This class implements the command service for handling payment-related commands.
/// </summary>
/// <param name="paymentRepository"></param>
/// <param name="unitOfWork"></param>
/// <param name="domainEventPublisher"></param>
public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IPlanRepository planRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher) : IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        // Validate if that user Id Exist In the facade
        //
        //
        //


        // Validate that the input value of status (command) exists in the EPaymentStatus enum
        var planExists = await planRepository.ExistById(command.PlanId);
        if (!planExists) throw new GeneralException("The Plan does not exist", "NOT_FOUND");


        // Validate if the plan status is within the valid range
        if (!Enum.IsDefined(typeof(EPaymentStatus), command.StatusId))
            throw new GeneralException("The Payment Status must be valid", "VALIDATION");

        // Process the command to create a new payment
        var payment = new Payment(command);
        if (command.StatusId == 1) payment.StatusId = 2;

        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new PaymentCreatedEvent(
            payment.UserId,
            payment.PlanId,
            payment.ScannerAmount,
            payment.PlanAmount,
            payment.ShipmentAmount,
            payment.SubtotalAmount,
            payment.TotalAmount,
            payment.PaymentDate,
            payment.StatusId
        ));
        return payment;
    }
}