namespace MedicDefense.API.LegalCase.Domain.Repositories;
using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Model;

public interface ILegalCaseRepository : IBaseRepository<Model.LegalCase>
{
    Task<IEnumerable<Model.LegalCase>> FindByIdAsync(int id);
    
    Task<Model.LegalCase> FindByCaseNumberAsync(string caseNumber);
    Task<Model.LegalCase> FindByDescriptionAsync(string description);
    Task<IEnumerable<Model.LegalCase>> FindByStatusAsync(string status);
}