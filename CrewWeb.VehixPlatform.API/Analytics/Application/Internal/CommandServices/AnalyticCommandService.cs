using Cortex.Mediator;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Model.Events;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Analytics.Application.Internal.CommandServices;

public class AnalyticCommandService(
    IAnalyticRepository analyticRepository,
    IUnitOfWork unitOfWork,
    IMediator domainEventPublisher
) : IAnalyticCommandService
{
    public async Task<Analytic?> Handle(CreateAnalyticCommand command)
    {
        // Validate If The Vehicle Id Exist In the facade
        //
        //

        // Validate If the Analytic Exist By Vehicle Id
        var analyticExists = await analyticRepository.ExistByVehicleId(command.VehicleId);
        if (!analyticExists)
            throw new GeneralException("The Analytic does not exist for the given Vehicle Id", "NOT_FOUND");

        // Validate system values
        if (command.Brake < 0 || command.Electrical < 0 || command.Engine < 0 || command.Fuel < 0 ||
            command.Refrigeration < 0 || command.Steering < 0 || command.Suspension < 0 || command.Transmission < 0)
            throw new GeneralException("The systems values cannot be negative", "VALIDATION");

        // Process the command to create a new analytic
        var analytic = new Analytic(command);
        await analyticRepository.AddAsync(analytic);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new AnalyticCreatedEvent(
            analytic.VehicleId,
            analytic.Brake,
            analytic.Electrical,
            analytic.Engine,
            analytic.Fuel,
            analytic.Refrigeration,
            analytic.Steering,
            analytic.Suspension,
            analytic.Transmission
        ));
        return analytic;
    }


    public async Task<Analytic?> Handle(UpdateAnalyticCommand command)
    {
        var analyticExists = analyticRepository.ExistByVehicleId(command.VehicleId);
        if (!analyticExists.Result)
            throw new GeneralException("The Analytic does not exist for the given Vehicle Id", "NOT_FOUND");

        // Validate system values
        if (command.Brake < 0 || command.Electrical < 0 || command.Engine < 0 || command.Fuel < 0 ||
            command.Refrigeration < 0 || command.Steering < 0 || command.Suspension < 0 || command.Transmission < 0)
            throw new GeneralException("The systems values cannot be negative", "VALIDATION");

        // Process the command to update the analytic
        var analytic = new Analytic(command);
        analyticRepository.Update(analytic);
        await unitOfWork.CompleteAsync();

        await domainEventPublisher.PublishAsync(new AnalyticCreatedEvent(
            analytic.VehicleId,
            analytic.Brake,
            analytic.Electrical,
            analytic.Engine,
            analytic.Fuel,
            analytic.Refrigeration,
            analytic.Steering,
            analytic.Suspension,
            analytic.Transmission
        ));
        return analytic;
    }
}