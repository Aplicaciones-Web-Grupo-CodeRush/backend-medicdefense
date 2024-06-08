using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Payment.Infrastructure.Persistence.EFC.Repositories;

public class PriceRepository(AppDbContext context) : BaseRepository<Price>(context), IPriceRepository
{

    public async Task<Price?> FindByIdAsync(int Id)
    {
        return await Context.Set<Price>()
            .FirstOrDefaultAsync(e => e.Id == Id);
    }

    public async Task<IEnumerable<Price?>> FindAllByLawyerIdAsync(int Id)
    {
        return await Context.Set<Price>()
            .Include(e => e.LawyerId == Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Price?>> FindAllByMedicIdAsync(int Id)
    {
        return await Context.Set<Price>()
            .Include(e => e.MedicId == Id)
            .ToListAsync();
    }
}