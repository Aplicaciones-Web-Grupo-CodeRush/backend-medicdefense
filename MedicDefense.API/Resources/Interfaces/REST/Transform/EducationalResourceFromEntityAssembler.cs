using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Interfaces.REST.Resources;

namespace MedicDefense.API.Resources.Interfaces.REST.Transform;

public class EducationalResourceFromEntityAssembler
{
    public static EducationalResourceR ToResourceFromEntity(EducationalResource entity)
    {
        return new EducationalResourceR(entity.Id, entity.Title, entity.Author, entity.ContentType, entity.VideoUrl);
    }
}