using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.ASM.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.ASM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.ASM.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.ASM.Application.Internal;

public class VehicleCommandService(
    IVehicleRepository vehicleRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher
) : IVehicleCommandService
{
    public async Task<Vehicle?> Handle(CreateVehicleCommand command)
    {
        if (command.Name == null || command.Name.Trim().Length == 0)
            throw new GeneralException("Vehicle name cannot be empty", "VALIDATION");

        if (!Enum.TryParse<EBrand>(command.Brand, ignoreCase: true, out _))
            throw new GeneralException("The Vehicle Brand must be valid", "VALIDATION");

        if (command.Mileage < 0 || command.Mileage > 999999)
            throw new GeneralException("Vehicle mileage cannot be negative", "VALIDATION");

        if (command.Year < 1900 || command.Year > DateTime.Now.Year)
            throw new GeneralException("Vehicle year must be between 1900 and the current year", "VALIDATION");

        if (command.ImageUrl == null || command.ImageUrl.Trim().Length == 0)
            throw new GeneralException("Vehicle image url cannot be empty", "VALIDATION");

        if (command.Model == null || command.Model.Trim().Length == 0)
            throw new GeneralException("Vehicle model cannot be empty", "VALIDATION");

        // Process the command to create a new vehicle
        var vehicle = new Vehicle(command);
        await vehicleRepository.AddAsync(vehicle);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new VehicleCreatedEvent(
            vehicle.UserId,
            vehicle.Description,
            vehicle.Name,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Mileage,
            vehicle.Year,
            vehicle.ImageUrl
        ));
        return vehicle;
    }

    public async Task<Vehicle?> Handle(UpdateVehicleCommand command)
    {
        var vehicleExists = await vehicleRepository.ExistById(command.Id);
        if (!vehicleExists)
            throw new GeneralException("The Vehicle does not exist", "NOT_FOUND");

        if (command.Name == null || command.Name.Trim().Length == 0)
            throw new GeneralException("Vehicle name cannot be empty", "VALIDATION");

        if (!Enum.TryParse<EBrand>(command.Brand, ignoreCase: true, out _))
            throw new GeneralException("The Vehicle Brand must be valid", "VALIDATION");

        if (command.Mileage < 0 || command.Mileage > 999999)
            throw new GeneralException("Vehicle mileage cannot be negative", "VALIDATION");

        if (command.Year < 1900 || command.Year > DateTime.Now.Year)
            throw new GeneralException("Vehicle year must be between 1900 and the current year", "VALIDATION");

        if (command.ImageUrl == null || command.ImageUrl.Trim().Length == 0)
            throw new GeneralException("Vehicle image url cannot be empty", "VALIDATION");

        // Process the command to update the vehicle
        var vehicle = new Vehicle(command);
        vehicleRepository.Update(vehicle);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new VehicleUpdatedEvent(
            vehicle.Id,
            vehicle.UserId,
            vehicle.Description,
            vehicle.Name,
            vehicle.Brand,
            vehicle.Model,
            vehicle.Mileage,
            vehicle.Year,
            vehicle.ImageUrl
        ));
        return vehicle;
    }
}