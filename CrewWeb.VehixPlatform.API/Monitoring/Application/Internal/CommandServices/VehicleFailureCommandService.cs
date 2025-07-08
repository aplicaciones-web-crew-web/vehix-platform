using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;

public class VehicleFailureCommandService(
    IVehicleFailureRepository vehicleFailureRepository,
    IFailureRepository failureRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher
) : IVehicleFailureCommandService
{
    public async Task<VehicleFailure?> Handle(CreateVehicleFailureCommand command)
    {
        var failureExist = await failureRepository.ExistById(command.FailureId);
        if (!failureExist)
            throw new GeneralException("The Failure does not exist", "VALIDATION");

        if (!Enum.TryParse<EStatus>(command.Status, ignoreCase: true, out _))
            throw new GeneralException("The Vehicle Failure Status must be valid", "VALIDATION");

        if (command.VehicleId <= 0)
            throw new GeneralException("The Vehicle Id must be valid", "VALIDATION");

        if (command.FailureId <= 0)
            throw new GeneralException("The Failure Id must be valid", "VALIDATION");

        // Process the command to create a new vehicle failure
        var vehicleFailure = new VehicleFailure(command);
        await vehicleFailureRepository.AddAsync(vehicleFailure);
        await unitOfWork.CompleteAsync();
        await domainEventPublisher.PublishAsync(new VehicleFailureCreatedEvent(
            vehicleFailure.VehicleId,
            vehicleFailure.FailureId,
            vehicleFailure.Date,
            vehicleFailure.Status
        ));
        return vehicleFailure;
    }

    public async Task<VehicleFailure?> Handle(UpdateVehicleFailureCommand command)
    {
        var vehicleFailureExists = await vehicleFailureRepository.ExistById(command.Id);
        if (!vehicleFailureExists)
            throw new GeneralException("The Vehicle Failure does not exist", "VALIDATION");

        var failureExist = await failureRepository.ExistById(command.FailureId);
        if (!failureExist)
            throw new GeneralException("The Failure does not exist", "VALIDATION");

        if (!Enum.TryParse<EStatus>(command.Status, ignoreCase: true, out _))
            throw new GeneralException("The Vehicle Failure Status must be valid", "VALIDATION");

        if (command.VehicleId <= 0)
            throw new GeneralException("The Vehicle Id must be valid", "VALIDATION");

        // Process the command to update the vehicle failure
        var vehicleFailure = new VehicleFailure(command);
        vehicleFailureRepository.Update(vehicleFailure);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new VehicleFailureUpdatedEvent(
            vehicleFailure.Id,
            vehicleFailure.VehicleId,
            vehicleFailure.FailureId,
            vehicleFailure.Date,
            vehicleFailure.Status
        ));
        return vehicleFailure;
    }
}