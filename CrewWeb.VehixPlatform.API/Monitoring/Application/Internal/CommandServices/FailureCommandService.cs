using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;

public class FailureCommandService(
    IFailureRepository failureRepository,
    IBadPracticeRepository badPracticeRepository,
    IOdbErrorRepository odbErrorRepository,
    IMediator domainEventPublisher,
    IUnitOfWork unitOfWork) : IFailureCommandService
{
    public async Task<Failure?> Handle(CreateFailureCommand command)
    {
        var badPracticeExists = await badPracticeRepository.ExistById(command.BadPracticeId);
        var odbErrorExists = await odbErrorRepository.ExistById(command.OdbErrorId);

        if (!badPracticeExists)
            throw new GeneralException("The Bad Practice does not exist", "VALIDATION");

        if (!odbErrorExists)
            throw new GeneralException("The ODB Error does not exist", "VALIDATION");

        if (command.Title == null || command.Title.Trim().Length == 0)
            throw new GeneralException("Failure title cannot be empty", "VALIDATION");

        if (command.SuggestSolution == null || command.SuggestSolution.Trim().Length == 0)
            throw new GeneralException("Failure suggest solution cannot be empty", "VALIDATION");

        if (!Enum.TryParse<EUrgency>(command.Urgency, ignoreCase: true, out _))
            throw new GeneralException("The Urgency Type be valid", "VALIDATION");


        // Process the command to create a new failure
        var failure = new Failure(command);
        await failureRepository.AddAsync(failure);
        await unitOfWork.CompleteAsync();
        await domainEventPublisher.PublishAsync(new FailureCreatedEvent(
            failure.Title,
            failure.SuggestSolution,
            failure.BadPracticeId,
            failure.OdbErrorId,
            failure.Urgency
        ));
        return failure;
    }
}