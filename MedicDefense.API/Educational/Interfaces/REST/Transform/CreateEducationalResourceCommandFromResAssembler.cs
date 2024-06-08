using MedicDefense.API.Educational.Domain.Model.Commands;
using MedicDefense.API.Educational.Interfaces.REST.Resources;

namespace MedicDefense.API.Educational.Interfaces.REST.Transform;

public static class CreateEducationalResourceCommandFromResAssembler
{
    public static CreateEducationalResourceCommand toCommandFromResource(CreateEducationalResourceRes resource)
    {
        return new CreateEducationalResourceCommand(resource.Title, resource.Author, resource.ContentType, resource.VideoUrl);
    }
}