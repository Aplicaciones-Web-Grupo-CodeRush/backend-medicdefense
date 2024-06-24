using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Model.Queries;
using MedicDefense.API.Educational.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Services;

namespace MedicDefense.API.Educational.Application.Internal.QueryServices;

public class EducationalResourceQueryService(IEducationalResourceRepository educationalResourceRepository)
    :IEducationalResourceQueryService
{
    public async Task<IEnumerable<EducationalResource>> Handle(GetEducationalResourceByIdQuery query)
    {
        return await educationalResourceRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<EducationalResource> Handle(GetEducationalResourceByTitleQuery query)
    {
        return await educationalResourceRepository.FindByTitleAsync(query.Title);
    }
    
    public async Task<EducationalResource> Handle(GetEducationalResourceByAuthorQuery query)
    {
        return await educationalResourceRepository.FindByAuthorAsync(query.Author);
    }
    
    public async Task<EducationalResource> Handle(GetEducationalResourceByAuthorAndTitleQuery query)
    {
        return await educationalResourceRepository.FindByAuthorAndTitleAsync(query.Author, query.Title);
    }
    public async Task<IEnumerable<EducationalResource>> Handle(GetAllEducationalResourceQuery query)
    {
        return await educationalResourceRepository.ListAsync();
    }
}