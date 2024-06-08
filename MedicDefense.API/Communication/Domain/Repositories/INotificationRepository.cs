using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.ValueObjects;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Communication.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<Notification?> FindNotificationByInformationAsync(Message information);
}