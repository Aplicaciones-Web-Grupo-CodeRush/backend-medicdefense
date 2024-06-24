namespace MedicDefense.API.Consultation.Interfaces.REST.Resources;

public record ConsultRes(int Id, DateTime Date, string LegalIssue,string Description, DoctorRes Doctor, LawyerRes Lawyer);