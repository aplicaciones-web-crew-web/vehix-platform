using CrewWeb.VehixPlatform.API.Management.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.Entities;
using CrewWeb.VehixPlatform.API.Management.Domain.Model.ValueObjects;
using CrewWeb.VehixPlatform.API.Management.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Management.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Management.Application.Internal.CommandServices;

public class VehicleCommandServices(
    IVehicleRepository vehicleRepository, 
    IUserVehicleProfileRepository userVehicleProfileRepository , 
    IUnitOfWork unitOfWork)
    : IVehicleCommandService
{
    public async Task<Vehicle?> Handle(CreateVehicleCommand command)
    {
        if(await vehicleRepository.ExistsByPlateAsync(command.Plate))
            throw new Exception("Vehicle with plate already exists");
        var newVehicle = new Vehicle(
            new UserId(command.OwnerId),
            new VehicleSpecs(command.Model, command.Brand, command.Year),
            command.FuelType,
            new Plate(command.Plate),
            new Mileage(command.Mileage)
        );
        await vehicleRepository.AddAsync(newVehicle);
        await unitOfWork.CompleteAsync();
        return newVehicle;
    }

    public async Task<Vehicle?> Handle(DeleteVehicleCommand command)
    {
        var vehicleToDelete = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicleToDelete is null)
            throw new Exception("No vehicle found");
        vehicleRepository.Remove(vehicleToDelete);
        await unitOfWork.CompleteAsync();
        return vehicleToDelete;
    }

    public async Task<Vehicle?> Handle(SetDefaultVehicleCommand command)
    {
        var vehicleToSetDefault = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicleToSetDefault is null)
            throw new Exception("No vehicle found");
        var userProfile = await userVehicleProfileRepository.FindByIdAsync(command.UserId);
        if(userProfile is null)
            throw new Exception("No user profile found");
        userProfile.Handle(command);
        userVehicleProfileRepository.Update(userProfile);
        await unitOfWork.CompleteAsync();
        var vehicleToReturn = userProfile.Vehicles.FirstOrDefault(v => v.Id == command.VehicleId);
        return vehicleToReturn;
    }

    public async Task<Vehicle> CreateVehicleAsync(CreateVehicleCommand createVehicleCommand)
    {
        if (await vehicleRepository.ExistsByPlateAsync(createVehicleCommand.Plate))
            throw new Exception("Vehicle with plate already exists");
        
        var newVehicle = new Vehicle(
            new UserId(createVehicleCommand.OwnerId),
            new VehicleSpecs(createVehicleCommand.Model, createVehicleCommand.Brand, createVehicleCommand.Year),
            createVehicleCommand.FuelType,
            new Plate(createVehicleCommand.Plate),
            new Mileage(createVehicleCommand.Mileage)
        );
        
        await vehicleRepository.AddAsync(newVehicle);
        await unitOfWork.CompleteAsync();
        
        return newVehicle;
    }
}