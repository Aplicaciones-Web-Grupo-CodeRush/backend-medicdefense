using MedicDefense.API.LegalCase.Domain.Model;
using MedicDefense.API.LegalCase.Domain.Model.Commands;

namespace MedicDefense.API.LegalCase.Domain.Services;


public interface ILegalCaseCommandService
{
    Task<Model.LegalCase> Handle(CreateLegalCaseCommand command);
}