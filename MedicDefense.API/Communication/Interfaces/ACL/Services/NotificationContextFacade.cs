using MedicDefense.API.Communication.Domain.Model.Commands;
using MedicDefense.API.Communication.Domain.Model.Queries;
using MedicDefense.API.Communication.Domain.Model.ValueObjects;
using MedicDefense.API.Communication.Domain.Services;

namespace MedicDefense.API.Communication.Interfaces.ACL.Services;

public class NotificationContextFacade(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService) : INotificationContextFacade
{
    public async Task<int> CreateNotification(string information)
    {
        var createNotificationCommand = new CreateNotificationCommand(information);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        return notification?.Id ?? 0;
    }

    public async Task<int> FetchNotificationIdByInformation(string information)
    {
        var getNotificationByInformationQuery = new GetNotificationByInformationQuery(new Message(information));
        var notification = await notificationQueryService.Handle(getNotificationByInformationQuery);
        return notification?.Id ?? 0;
    }
}