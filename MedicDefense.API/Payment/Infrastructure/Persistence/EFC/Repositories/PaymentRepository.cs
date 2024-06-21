using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Payment.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository: BaseRepository<Domain.Model.Aggregates.Payment>,IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }
    public new async Task<IEnumerable<Domain.Model.Aggregates.Payment>> FindByIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.Payment>()
            .Where(e => e.Id == id)
            .ToListAsync();
    }
    public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> FindByPayerIdAsync(long payerId)
    { return await Context.Set<Domain.Model.Aggregates.Payment>()
        .Where(e => e.PayerId == payerId)
        .ToListAsync();
    }
    public async Task<IEnumerable<Domain.Model.Aggregates.Payment>> FindByReceiverIdAsync(long receiverId)
    { return await Context.Set<Domain.Model.Aggregates.Payment>()
        .Where(e => e.ReceiverId == receiverId)
        .ToListAsync();
    }
    public new async Task<IEnumerable<Domain.Model.Aggregates.Payment>> ListAsync()
    { return await Context.Set<Domain.Model.Aggregates.Payment>()
        .ToListAsync();
    }
}