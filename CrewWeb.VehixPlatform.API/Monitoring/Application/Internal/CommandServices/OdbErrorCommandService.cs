using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;

public class OdbErrorCommandService(
    IOdbErrorRepository odbErrorRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher)
    : IOdbErrorCommandService
{
    public async Task<OdbError?> Handle(CreateOdbErrorCommand command)
    {
        var odbErrorExists = await odbErrorRepository.ExistByCode(command.Code);
        if (odbErrorExists)
            throw new GeneralException("The ODB Error with the given code already exists.", "VALIDATION");

        if (command.Title == null || command.Title.Trim().Length == 0)
            throw new GeneralException("ODB Error title cannot be empty.", "VALIDATION");


        if (!Enum.TryParse<EOdbCode>(command.Code, ignoreCase: true, out _))
            throw new GeneralException("The ODB Code must be valid", "VALIDATION");

        if (!Enum.TryParse<EType>(command.Type, ignoreCase: true, out _))
            throw new GeneralException("The Type of odb Error must be valid", "VALIDATION");


        var odbError = new OdbError(command);
        await odbErrorRepository.AddAsync(odbError);
        await unitOfWork.CompleteAsync();
        // Publish the domain event after the OdbError is created
        await domainEventPublisher.PublishAsync(new OdbErrorCreatedEvent(
            odbError.Code,
            odbError.Title,
            odbError.Type));
        return odbError;
    }
}