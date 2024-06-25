using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Commands;
using MedicDefense.API.Profiles.Interfaces.REST.Resources;

namespace MedicDefense.API.Profiles.Interfaces.REST.Transform;

public static class CreateLawyersCommandFromResAssembler
{
    public static CreateLawyersCommand ToCommandFromResource(CreateLawyersRes resource)
    {
        return new CreateLawyersCommand(
            resource.Name,
            resource.YearsOfExperience,
            resource.Specialization,
            resource.UrlToImage,
            resource.CasesWon,
            resource.Price,
            resource.Email,
            resource.PhoneNumber
        );
    }
    
}