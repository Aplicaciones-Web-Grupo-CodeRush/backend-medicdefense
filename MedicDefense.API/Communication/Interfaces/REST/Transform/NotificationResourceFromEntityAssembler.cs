using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Communication.Interfaces.REST.Resources;

namespace MedicDefense.API.Communication.Interfaces.REST.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToResourceFromEntity(Notification entity)
    {
        return new NotificationResource(entity.Id, entity.Message);
    }
}