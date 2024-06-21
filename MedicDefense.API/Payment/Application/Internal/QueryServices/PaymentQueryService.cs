using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;

namespace MedicDefense.API.Payment.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository) : IPaymentQueryService
{
 public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetPaymentByIdQuery query)
 {
     return await paymentRepository.FindByIdAsync(query.Id);
 }
 public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetPaymentsByPayerIdQuery query)
 {
     return await paymentRepository.FindByPayerIdAsync(query.PayerId);
 }
 public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetPaymentsByReceiverIdQuery query)
 {
     return await paymentRepository.FindByReceiverIdAsync(query.ReceiverId);
 }
 public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> Handle(GetAllPaymentsQuery query)
 {
     return await paymentRepository.ListAsync();
 }
}