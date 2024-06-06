using MedicDefense.API.Resources.Domain.Model.Aggregates;
using MedicDefense.API.Resources.Domain.Model.Commands;

namespace MedicDefense.API.Resources.Domain.Services;

public interface IEducationalResourceCommandService
{
    Task<EducationalResource> Handle(CreateEducationalResourceCommand command);
}