using MedicDefense.API.Profiles.Domain.Model.Commands;
using MedicDefense.API.Profiles.Interfaces.REST.Resources;

namespace MedicDefense.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileRes resource)
    {
        return new CreateProfileCommand(
            resource.Name,
            resource.Email,
            resource.DNI,
            resource.ImageUrl,
            resource.Specialities,
            resource.PhoneNumber);
    }
}