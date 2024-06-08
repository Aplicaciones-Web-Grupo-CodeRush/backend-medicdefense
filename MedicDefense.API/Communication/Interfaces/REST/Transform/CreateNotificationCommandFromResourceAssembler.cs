using MedicDefense.API.Communication.Domain.Model.Commands;
using MedicDefense.API.Communication.Interfaces.REST.Resources;

namespace MedicDefense.API.Communication.Interfaces.REST.Transform;

public static class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(resource.Information);
    }
}