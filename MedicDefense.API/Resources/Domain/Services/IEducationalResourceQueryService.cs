using MedicDefense.API.Resources.Domain.Model.Queries;
using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Domain.Model.Queries;

namespace MedicDefense.API.Resources.Domain.Services;

public interface IEducationalResourceQueryService
{
    Task<EducationalResource?> Handle(GetEducationalResourceByTitleQuery query);
    Task<EducationalResource?> Handle(GetEducationalResourceByTitleAndAuthorQuery query);
    Task<EducationalResource?> Handle(GetEducationalResourceByIdQuery query);
    Task<IEnumerable<EducationalResource>> Handle(GetAllEducationalResourceQuery query);
}