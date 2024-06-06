using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Resources.Infrastructure.Persistence.EFC.Repositories;

public class EducationalResourceRepository : BaseRepository<EducationalResource>, IEducationalResourceRepository
{
    public EducationalResourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<EducationalResource?> FindByTitleAsync(string Title)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(e => e.Title == Title);
    }

    public async Task<EducationalResource?> FindByTitleAndAuthorAsync(string Title, string Author)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(e => e.Title == Title && e.Author == Author);
    }

    public async Task<EducationalResource?> FindByIdAsync(string Id)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(e => Equals(e.Id, Id));
    }

    public Task<IEnumerable<EducationalResource>> FindAllAsync()
    {
        throw new NotImplementedException();
    }
}