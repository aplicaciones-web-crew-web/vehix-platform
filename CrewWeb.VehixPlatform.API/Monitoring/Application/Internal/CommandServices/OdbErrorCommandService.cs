using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
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
        var odbError = new OdbError(command);
        await odbErrorRepository.AddAsync(odbError);
        await unitOfWork.CompleteAsync();
        // Publish the domain event after the OdbError is created
        await domainEventPublisher.PublishAsync(new OdbErrorCreatedEvent(odbError.ErrorCode, odbError.ErrorCodeTitle,
            odbError.ErrorCodeType));
        return odbError;
    }
}