using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Queries;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPaymentInfoQueryService
{
    Task<PaymentInfo?> Handle(GetPaymentInfoByIdQuery query);
    Task<IEnumerable<PaymentInfo>> Handle(GetAllPaymentInfosQuery query);
    Task<IEnumerable<PaymentInfo>> Handle(GetAllPaymentInfoByPriceIdQuery query);
}