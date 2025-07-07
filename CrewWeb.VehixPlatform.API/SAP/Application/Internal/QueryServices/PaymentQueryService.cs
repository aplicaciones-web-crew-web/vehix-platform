using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Aggregates;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;

namespace CrewWeb.VehixPlatform.API.SAP.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.PaymentId);
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }
}