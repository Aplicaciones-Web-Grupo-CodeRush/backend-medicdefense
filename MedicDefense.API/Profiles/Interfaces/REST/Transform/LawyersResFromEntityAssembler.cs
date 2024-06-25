using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Interfaces.REST.Resources;

namespace MedicDefense.API.Profiles.Interfaces.REST.Transform;

public static class LawyersResFromEntityAssembler
{
    public static LawyersRes ToResourceFromEntity(LawyersUsers entity)
    {
        return new LawyersRes(
            entity.Id,
            entity.Name,
            entity.YearsOfExperience,
            entity.Specialization,
            entity.UrlToImage,
            entity.CasesWon,
            entity.Price,
            entity.Email,
            entity.PhoneNumber
        );
    }
}