namespace MedicDefense.API.LegalCase.Domain.Model.Commands;

public record CreateLegalCaseCommand(string CaseNumber, string Description, string Status);
