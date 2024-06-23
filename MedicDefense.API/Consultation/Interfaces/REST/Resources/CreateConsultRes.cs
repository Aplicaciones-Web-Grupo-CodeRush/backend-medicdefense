namespace MedicDefense.API.Consultation.Interfaces.REST.Resources;

public record CreateConsultRes(DateTime Date, string LegalIssue, DoctorRes Doctor, LawyerRes Lawyer);