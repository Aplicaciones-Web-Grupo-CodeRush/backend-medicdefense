using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Interfaces.REST.Resources;

namespace MedicDefense.API.Educational.Interfaces.REST.Transform;

public static class EducationalResourceResFromEntityAssembler
{
    public static EducationalResourceRes toResourceFromEntity(EducationalResource educationalResource)
    {
        return new EducationalResourceRes(educationalResource.Id, educationalResource.Title, educationalResource.Author, educationalResource.ContentType, educationalResource.VideoUrl);
    }
}