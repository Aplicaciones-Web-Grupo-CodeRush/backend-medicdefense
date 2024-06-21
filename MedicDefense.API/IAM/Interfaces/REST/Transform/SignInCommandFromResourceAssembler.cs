using MedicDefense.API.IAM.Domain.Model.Commands;
using MedicDefense.API.IAM.Interfaces.REST.Resources;

namespace MedicDefense.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}