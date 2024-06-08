using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Model.Aggregates;

namespace MedicDefense.API.Educational.Domain.Repositories;

public interface IEducationalResourceRepository : IBaseRepository<EducationalResource>
{
    Task<IEnumerable<EducationalResource>> FindByIdAsync(int id);
    Task<EducationalResource> FindByAuthorAsync(string author);
    Task<EducationalResource> FindByTitleAsync(string title);
    Task<EducationalResource> FindByAuthorAndTitleAsync(string author, string title);
}