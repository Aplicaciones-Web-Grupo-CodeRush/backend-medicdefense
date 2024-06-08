using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Domain.Repositories;

public interface IPriceRepository: IBaseRepository<Price>
{
    Task<Price?> FindByIdAsync(int Id);
    
    Task<IEnumerable<Price>> FindAllByMedicIdAsync(int MedicId);
    
    Task<IEnumerable<Price>> FindAllByLawyerIdAsync(int LawyerId);
}