using MedicDefense.API.LegalCase.Interfaces.REST.Resources;

namespace MedicDefense.API.LegalCase.Interfaces.REST.Transform;

public static class LegalCaseResourceFromEntityAssembler
{
    public static LegalCaseResource toResourceFromEntity(Domain.Model.LegalCase legalCase)
    {
        return new LegalCaseResource(legalCase.Id, legalCase.CaseNumber, legalCase.Description, legalCase.Status);
    }
}