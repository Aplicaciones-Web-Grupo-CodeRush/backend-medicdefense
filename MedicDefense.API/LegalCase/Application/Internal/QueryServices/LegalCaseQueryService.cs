using MedicDefense.API.LegalCase.Domain.Model.Queries;
using MedicDefense.API.LegalCase.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Services;

namespace MedicDefense.API.LegalCase.Application.Internal.QueryServices;

public class LegalCaseQueryService(ILegalCaseRepository legalCaseRepository) 
    : ILegalCaseQueryService
{
    public async Task<IEnumerable<Domain.Model.LegalCase>> Handle(GetLegalCasesByIdQuery query)
    {
        return await legalCaseRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<Domain.Model.LegalCase> Handle(GetLegalCaseByCaseNumberQuery query)
    {
        return await legalCaseRepository.FindByCaseNumberAsync(query.CaseNumber);
    }
    
    public async Task<Domain.Model.LegalCase> Handle(GetLegalCaseByDescriptionQuery query)
    {
        return await legalCaseRepository.FindByDescriptionAsync(query.Description);
    }
    
    public async Task<Domain.Model.LegalCase> Handle(GetLegalCaseByStatusQuery query)
    {
        return await legalCaseRepository.FindByStatusAsync(query.Status);
    }
}