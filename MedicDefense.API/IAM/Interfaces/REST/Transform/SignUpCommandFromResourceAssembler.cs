using MedicDefense.API.IAM.Domain.Model.Commands;
using MedicDefense.API.IAM.Interfaces.REST.Resources;

namespace MedicDefense.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}