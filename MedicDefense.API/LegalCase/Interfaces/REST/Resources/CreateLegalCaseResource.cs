namespace MedicDefense.API.LegalCase.Interfaces.REST.Resources;

public record CreateLegalCaseResource(string CaseNumber, string Description, string Status);