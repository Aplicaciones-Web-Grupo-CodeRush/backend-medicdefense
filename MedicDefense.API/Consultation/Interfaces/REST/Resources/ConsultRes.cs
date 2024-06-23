namespace MedicDefense.API.Consultation.Interfaces.REST.Resources;

public record ConsultRes(int Id, DateTime Date, string LegalIssue, DoctorRes Doctor, LawyerRes Lawyer);