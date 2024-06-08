using MedicDefense.API.LegalCase.Domain.Model.Commands;
using MedicDefense.API.LegalCase.Interfaces.REST.Resources;

namespace MedicDefense.API.LegalCase.Interfaces.REST.Transform;

public static class CreateLegalCaseCommandFromResourceAssembler
{
    public static CreateLegalCaseCommand toCommandFromResource(CreateLegalCaseResource resource)
    {
        return new CreateLegalCaseCommand(resource.CaseNumber, resource.Description, resource.Status);
    }
}