using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Model.Commands;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;

namespace MedicDefense.API.Consultation.Interfaces.REST.Transform;

public static class CreateConsultCommandFromResAssembler
{
    public static CreateConsultCommand ToCommandFromResource(CreateConsultRes resource)
    {
        return new CreateConsultCommand(resource.Date, resource.LegalIssue, 
            new Doctor(resource.Doctor.Id, resource.Doctor.Name, resource.Doctor.Specialty), 
            new Lawyer(resource.Lawyer.Id, resource.Lawyer.Name, resource.Lawyer.Specialty));
    }
}