using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Resources.Domain.Repositories;

public interface IEducationalResourceRepository : IBaseRepository<EducationalResource>
{
    Task<EducationalResource?> FindByTitleAsync(string Title);
    
    Task<EducationalResource?> FindByTitleAndAuthorAsync(string Title, string Author);
    
    Task<EducationalResource?> FindByIdAsync(int Id);
    
    Task<IEnumerable<EducationalResource>> FindAllAsync();
}