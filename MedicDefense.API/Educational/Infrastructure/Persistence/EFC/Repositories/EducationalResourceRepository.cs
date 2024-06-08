using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Educational.Infrastructure.Persistence.EFC.Repositories;

public class EducationalResourceRepository : BaseRepository<EducationalResource>, IEducationalResourceRepository
{
    public EducationalResourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EducationalResource>> FindByIdAsync(int id)
    {
        return await Context.Set<EducationalResource>()
            .Where(l => l.Id == id)
            .ToListAsync();
    }

    public async Task<EducationalResource> FindByAuthorAsync(string author)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(l => l.Author == author);
    }

    public async Task<EducationalResource> FindByTitleAsync(string title)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(l => l.Title == title);
    }

    public async Task<EducationalResource> FindByAuthorAndTitleAsync(string author, string title)
    {
        return await Context.Set<EducationalResource>()
            .FirstOrDefaultAsync(l => l.Author == author && l.Title == title);
    }
}