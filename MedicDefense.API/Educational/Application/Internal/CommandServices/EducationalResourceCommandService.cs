using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Model.Commands;
using MedicDefense.API.Educational.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Services;

namespace MedicDefense.API.Educational.Application.Internal.CommandServices;

public class EducationalResourceCommandService(IEducationalResourceRepository educationalResourceRepository, IUnitOfWork unitOfWork) 
    : IEducationalResourceCommandService
{
    public async Task<EducationalResource> Handle(CreateEducationalResourceCommand command)
    {
        var educationalResource = await educationalResourceRepository.FindByAuthorAndTitleAsync(
            command.Author, command.Title);
        if (educationalResource != null)
            throw new Exception("Legal case with this CaseNumber already exists");
        educationalResource = new EducationalResource(command);
        await educationalResourceRepository.AddAsync(educationalResource);
        await unitOfWork.CompleteAsync();
        return educationalResource;
    }
    
}