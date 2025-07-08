using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;

public class BadPracticeCommandService(
    IBadPracticeRepository badPracticeRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IBadPracticeCommandService
{
    public async Task<BadPractice?> Handle(CreateBadPracticeCommand command)
    {
        if (command.DescriptionBadPractice == null || command.DescriptionBadPractice.Trim().Length == 0)
            throw new GeneralException("Description of bad practice cannot be empty.", "VALIDATION_ERROR");

        var badPractice = new BadPractice(command);
        await badPracticeRepository.AddAsync(badPractice);
        await unitOfWork.CompleteAsync();
        // Publish the domain event after the bad practice is created
        await domainEventPublisher.PublishAsync(new BadPracticeCreatedEvent(
            badPractice.DescriptionBadPractice
            ));
        return badPractice;
    }
}