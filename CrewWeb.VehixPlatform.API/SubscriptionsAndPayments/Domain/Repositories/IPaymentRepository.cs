using CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Model.Aggregates;

namespace CrewWeb.VehixPlatform.API.SubscriptionsAndPayments.Domain.Repositories;

public interface IPaymentRepository
{
    Task<Payment> Create(Payment payment);
    void update(Payment payment);
    Task<Payment?> GetById(Guid paymentId);
    Task<IEnumerable<Payment>> GetAll();
}