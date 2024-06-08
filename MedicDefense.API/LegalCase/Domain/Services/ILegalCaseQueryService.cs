using MedicDefense.API.LegalCase.Domain.Model.Queries;

namespace MedicDefense.API.LegalCase.Domain.Services;

public interface ILegalCaseQueryService
{
    Task<IEnumerable<Model.LegalCase>> Handle(GetLegalCasesByIdQuery query);
    Task<Model.LegalCase> Handle(GetLegalCaseByCaseNumberQuery query);
    Task<Model.LegalCase> Handle(GetLegalCaseByDescriptionQuery query);
    Task<Model.LegalCase> Handle(GetLegalCaseByStatusQuery query);
}