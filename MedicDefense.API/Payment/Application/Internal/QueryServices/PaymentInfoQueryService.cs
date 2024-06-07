using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;

namespace MedicDefense.API.Payment.Application.Internal.QueryServices;

public class PaymentInfoQueryService(IPaymentInfoRepository paymentInfoRepository): IPaymentInfoQueryService
{
    public async Task<PaymentInfo?> Handle(GetPaymentInfoByIdQuery query)
    {
        return await paymentInfoRepository.FindByIdAsync(query.PaymentInfoId);
    }
    public async Task<IEnumerable<PaymentInfo>> Handle(GetAllPaymentInfosQuery query)
    {
        return await paymentInfoRepository.FindAllAsync();
    }
    public async Task<IEnumerable<PaymentInfo>> Handle(GetAllPaymentInfoByPriceIdQuery query)
    {
        return await paymentInfoRepository.FindAllByPriceIdAsync(query.PriceId);
    }
}