using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.Commands;
using MedicDefense.API.Communication.Domain.Repositories;
using MedicDefense.API.Communication.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Communication.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task<Notification?> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(command);
        try
        {
            await notificationRepository.AddAsync(notification);
            await unitOfWork.CompleteAsync();
            return notification;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}