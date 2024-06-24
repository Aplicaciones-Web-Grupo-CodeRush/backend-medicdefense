namespace MedicDefense.API.Consultation.Interfaces.REST.Resources;

public record CreateConsultRes(DateTime Date, string LegalIssue, string Description, DoctorRes Doctor, LawyerRes Lawyer);