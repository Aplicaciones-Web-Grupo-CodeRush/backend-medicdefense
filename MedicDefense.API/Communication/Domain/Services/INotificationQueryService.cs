using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Domain.Model.Queries;

namespace MedicDefense.API.Communication.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    Task<Notification?> Handle(GetNotificationByIdQuery query);
    Task<Notification?> Handle(GetNotificationByInformationQuery query);
}