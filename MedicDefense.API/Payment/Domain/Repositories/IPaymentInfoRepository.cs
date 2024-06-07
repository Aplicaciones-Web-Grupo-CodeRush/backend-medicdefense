using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Domain.Repositories;

public interface IPaymentInfoRepository : IBaseRepository<PaymentInfo>
{
    Task<PaymentInfo?> FindByIdAsync(int Id);
    
    Task<IEnumerable<PaymentInfo>> FindAllByPriceIdAsync(int LawyerId);
    
    Task<IEnumerable<PaymentInfo>> FindAllAsync();
}