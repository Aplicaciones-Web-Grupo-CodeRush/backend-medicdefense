using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.Queries;
using MedicDefense.API.Communication.Domain.Repositories;
using MedicDefense.API.Communication.Domain.Services;

namespace MedicDefense.API.Communication.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }

    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId);
    }

    public async Task<Notification?> Handle(GetNotificationByInformationQuery query)
    {
        return await notificationRepository.FindNotificationByInformationAsync(query.Information);
    }
}