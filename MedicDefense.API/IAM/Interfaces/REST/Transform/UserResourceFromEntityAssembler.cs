using MedicDefense.API.IAM.Domain.Model.Aggregates;
using MedicDefense.API.IAM.Interfaces.REST.Resources;

namespace MedicDefense.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}