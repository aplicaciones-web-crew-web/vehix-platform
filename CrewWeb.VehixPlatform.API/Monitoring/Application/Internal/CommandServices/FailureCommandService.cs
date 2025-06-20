using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Model.Commands;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;

namespace CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;

public class FailureCommandService(
    IFailureRepository failureRepository,
    IBadPracticeRepository badPracticeRepository,
    IOdbErrorRepository odbErrorRepository,
    IUnitOfWork unitOfWork) : IFailureCommandService
{
    public async Task<Failure?> Handle(CreateFailureCommand command)
    {
        var badPractice = await badPracticeRepository.FindByIdAsync(command.BadPracticeId);
        if (badPractice is null) throw new Exception("Bad practice not found");
        var odbError = await odbErrorRepository.FindByIdAsync(command.OdbErrorId);
        if (odbError is null) throw new Exception("Odb error not found");
        
        
        var failure = new Failure(command);
        //Give you the failure and mark as "new" or "add". Maintain that in your pending changes list
        await failureRepository.AddAsync(failure);
        //collects all the changes it has been tracking
        await unitOfWork.CompleteAsync();
        
        failure.OdbError = odbError;
        failure.BadPractice = badPractice;
        return failure;
    }
}