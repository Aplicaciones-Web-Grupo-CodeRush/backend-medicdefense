using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Domain.Model.Commands;
using MedicDefense.API.Resources.Domain.Repositories;
using MedicDefense.API.Resources.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Resources.Application.Internal.CommandServices;

public class EducationalResourceCommandService(IEducationalResourceRepository educationalResourceRepository, IUnitOfWork unitOfWork)
: IEducationalResourceCommandService
{
    public async Task<EducationalResource> Handle(CreateEducationalResourceCommand command)
    {
        var educationalResource = await educationalResourceRepository.FindByTitleAndAuthorAsync(
            command.Title, command.Author);
        if (educationalResource != null)
            throw new Exception("Educational resource with this Title and Author already exists");
        educationalResource = new EducationalResource(command);
        await educationalResourceRepository.AddAsync(educationalResource);
        await unitOfWork.CompleteAsync();
        return educationalResource;
    }
}