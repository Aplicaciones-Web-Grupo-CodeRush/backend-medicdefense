using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.ValueObjects;
using MedicDefense.API.Communication.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public Task<Notification?> FindNotificationByInformationAsync(Message information)
    {
        return Context.Set<Notification>().Where(p => p.Information == information).FirstOrDefaultAsync();
    }
}