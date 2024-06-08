using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Model.Commands;

namespace MedicDefense.API.Educational.Domain.Services;

public interface IEducationalResourceCommandService
{
    Task<EducationalResource> Handle(CreateEducationalResourceCommand command);

}