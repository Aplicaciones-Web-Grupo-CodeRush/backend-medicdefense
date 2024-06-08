using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Model.Queries;

namespace MedicDefense.API.Educational.Domain.Services;

public interface IEducationalResourceQueryService
{
    Task<IEnumerable<EducationalResource>> Handle(GetEducationalResourceByIdQuery query);
    Task<EducationalResource> Handle(GetEducationalResourceByTitleQuery query);
    Task<EducationalResource> Handle(GetEducationalResourceByAuthorQuery query);
    Task<EducationalResource> Handle(GetEducationalResourceByAuthorAndTitleQuery query);
}