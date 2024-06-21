using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Model.Aggregates.Payment>
{
    new Task<IEnumerable<Domain.Model.Aggregates.Payment>> FindByIdAsync(int id);
    Task<IEnumerable<Model.Aggregates.Payment>> FindByPayerIdAsync(long payerId);
    Task<IEnumerable<Model.Aggregates.Payment>> FindByReceiverIdAsync(long receiverId);
}