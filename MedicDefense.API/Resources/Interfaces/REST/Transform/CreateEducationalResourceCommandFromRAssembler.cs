using MedicDefense.API.Resources.Domain.Model.Commands;
using MedicDefense.API.Resources.Interfaces.REST.Resources;

namespace MedicDefense.API.Resources.Interfaces.REST.Transform;

public static class CreateEducationalResourceCommandFromRAssembler
{
    public static CreateEducationalResourceCommand ToCommandFromResource(CreateEducationalResourceR resource)
    {
        return new CreateEducationalResourceCommand(resource.Title, resource.Author, resource.ContentType,resource.Url);
    }   
}