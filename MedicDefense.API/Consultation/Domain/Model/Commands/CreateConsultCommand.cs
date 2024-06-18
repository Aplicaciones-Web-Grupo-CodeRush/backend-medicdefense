using MedicDefense.API.Consultation.Domain.Model.Aggregates;

namespace MedicDefense.API.Consultation.Domain.Model.Commands;

public record CreateConsultCommand( DateTime Date, string LegalIssue, Doctor Doctor, Lawyer Lawyer);