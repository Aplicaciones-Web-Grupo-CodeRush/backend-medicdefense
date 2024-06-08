using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.Commands;

namespace MedicDefense.API.Communication.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
}