using MedicDefense.API.LegalCase.Domain.Model.Commands;

namespace MedicDefense.API.LegalCase.Domain.Model;

public class LegalCase
{
    public int Id { get; private set; }
    
    public string CaseNumber { get; private set; }
    
    public string Description { get; private set; }
    
    public string Status { get; private set; }

    protected LegalCase()
    {
        this.CaseNumber = string.Empty;
        this.Description = string.Empty;
        this.Status = string.Empty;
    }

    public LegalCase(CreateLegalCaseCommand command)
    {
        this.CaseNumber = command.CaseNumber;
        this.Description = command.Description;
        this.Status = command.Status;
    }
    
    
}