using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Payment.Infrastructure.Persistence.EFC.Repositories;

public class CardInfoRepository(AppDbContext context): BaseRepository<CardInfo>(context), ICardInfoRepository
{

    public async Task<CardInfo?> FindByIdAsync(int Id)
    {
        return await Context.Set<CardInfo>()
            .FirstOrDefaultAsync(e => e.Id == Id);
    }

    public async Task<IEnumerable<CardInfo?>> FindAllAsync()
    {
        return await Context.Set<CardInfo>()
            .Include(e => e.CardNumber)
            .Include(e=>e.CardHolderName)
            .ToListAsync();
    }
}