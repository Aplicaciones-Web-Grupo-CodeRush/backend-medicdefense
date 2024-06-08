using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Payment.Infrastructure.Persistence.EFC.Repositories;

public class PaymentInfoRepository(AppDbContext context): BaseRepository<PaymentInfo>(context), IPaymentInfoRepository
{

    public async Task<Price?> FindByIdAsync(int Id)
    {
        return await Context.Set<Price>()
            .FirstOrDefaultAsync(e => e.Id == Id);
    }

    public async Task<IEnumerable<PaymentInfo?>> FindAllAsync()
    {
        return await Context.Set<PaymentInfo>()
            .Include(e => e.CardInfoId)
            .Include(e=>e.PriceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<PaymentInfo?>> FindAllByPriceIdAsync(int Id)
    {
        return await Context.Set<PaymentInfo>()
            .Include(e => e.PriceId == Id)
            .ToListAsync();
    }
}