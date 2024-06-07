using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Model.Commands;
using MedicDefense.API.LegalCase.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Services;

namespace MedicDefense.API.LegalCase.Application.Internal.CommandServices;

public class LegalCaseCommandService(ILegalCaseRepository legalCaseRepository, IUnitOfWork unitOfWork) 
    : ILegalCaseCommandService
{
    public async Task<Domain.Model.LegalCase> Handle(CreateLegalCaseCommand command)
    {
        var legalCase = await legalCaseRepository.FindByCaseNumberAsync(
            command.CaseNumber);
        if (legalCase != null)
            throw new Exception("Legal case with this CaseNumber already exists");
        legalCase = new Domain.Model.LegalCase(command);
        await legalCaseRepository.AddAsync(legalCase);
        await unitOfWork.CompleteAsync();
        return legalCase;
    }
}