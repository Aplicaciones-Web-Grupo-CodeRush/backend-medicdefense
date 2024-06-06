using MedicDefense.API.Resources.Domain.Model.Queries;
using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Domain.Repositories;
using MedicDefense.API.Resources.Domain.Services;

namespace MedicDefense.API.Resources.Application.Internal.QueryServices;

public class EducationalResourceQueryService(IEducationalResourceRepository educationalResourceRepository)
: IEducationalResourceQueryService
{
    public async Task<EducationalResource?> Handle(GetEducationalResourceByTitleQuery query)
    {
        return await educationalResourceRepository.FindByTitleAsync(query.Title);
    }

    public async Task<EducationalResource?> Handle(GetEducationalResourceByTitleAndAuthorQuery query)
    {
        return await educationalResourceRepository.FindByTitleAndAuthorAsync(query.Title, query.Author);
    }

    public async Task<EducationalResource?> Handle(GetEducationalResourceByIdQuery query)
    {
        return await educationalResourceRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<EducationalResource>> Handle(GetAllEducationalResourceQuery query)
    {
        return await educationalResourceRepository.FindAllAsync();
    }
}