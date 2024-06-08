using MedicDefense.API.LegalCase.Domain.Repositories;

namespace MedicDefense.API.LegalCase.Interfaces.REST.Resources;

public record LegalCaseResource(int Id, string CaseNumber, string Description, string Status);