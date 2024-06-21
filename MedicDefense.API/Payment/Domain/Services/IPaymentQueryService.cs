using MedicDefense.API.Payment.Domain.Model.Queries;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPaymentQueryService
{
    Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetPaymentByIdQuery query);
    Task<IEnumerable<Model.Aggregates.Payment>> Handle(GetPaymentsByPayerIdQuery query);
    Task<IEnumerable<Model.Aggregates.Payment>> Handle(GetPaymentsByReceiverIdQuery query);
    Task<IEnumerable<Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query);
}