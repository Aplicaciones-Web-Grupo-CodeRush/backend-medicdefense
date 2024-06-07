using System.Runtime.InteropServices.JavaScript;

namespace MedicDefense.API.Consultation.Domain;

public class Consult
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string LegalIssue { get; set; }
    public Doctor Doctor { get; set; }
    public Lawyer Lawyer { get; set; }
}