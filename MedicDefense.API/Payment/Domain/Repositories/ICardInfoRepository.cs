using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Domain.Repositories;

public interface ICardInfoRepository : IBaseRepository<CardInfo>
{
    Task<CardInfo?> FindByIdAsync(int Id);
    
    Task<IEnumerable<CardInfo>> FindAllAsync();
}