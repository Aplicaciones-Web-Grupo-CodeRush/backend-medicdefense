using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Interfaces.REST.Resources;

namespace MedicDefense.API.Profiles.Interfaces.REST.Transform;

public static class ProfileResFromEntityAssembler
{
    public static ProfileRes ToResourceFromEntity(Profile profile)
    {
        return new ProfileRes(
            profile.Id,
            profile.Name,
            profile.Email,
            profile.DNI,
            profile.ImageUrl,
            profile.Specialities,
            profile.PhoneNumber);
    }
}