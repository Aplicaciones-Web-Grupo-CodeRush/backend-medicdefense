using MedicDefense.API.Consultation.Domain.Model.Commands;

namespace MedicDefense.API.Consultation.Domain.Model.Aggregates;

public class Consult
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public string LegalIssue { get; private set; }
    public Doctor Doctor { get; private set; }
    public Lawyer Lawyer { get; private set; }

    protected Consult()
    {
        this.Date = default;
        this.LegalIssue = string.Empty;
        this.Doctor = null;
        this.Lawyer = null;
    }

    public Consult(CreateConsultCommand command)
    {
        this.Date = command.Date;
        this.LegalIssue = command.LegalIssue;
        this.Doctor = command.Doctor;
        this.Lawyer = command.Lawyer;
    }

    public void SetDate(DateTime date)
    {
        this.Date = date;
    }

    public void SetLegalIssue(string legalIssue)
    {
        this.LegalIssue = legalIssue;
    }
    public void SetDoctor(Doctor doctor)
    {
        this.Doctor = doctor;
    }

    public void SetLawyer(Lawyer lawyer)
    {
        this.Lawyer = lawyer;
    }
}