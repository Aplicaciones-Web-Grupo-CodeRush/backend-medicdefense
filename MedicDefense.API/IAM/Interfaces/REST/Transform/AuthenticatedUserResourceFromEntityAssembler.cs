using MedicDefense.API.IAM.Domain.Model.Aggregates;
using MedicDefense.API.IAM.Interfaces.REST.Resources;

namespace MedicDefense.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}