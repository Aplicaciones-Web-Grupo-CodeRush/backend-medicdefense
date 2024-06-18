using MedicDefense.API.Consultation.Domain.Model.Commands;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;

namespace MedicDefense.API.Consultation.Interfaces.REST.Transform;

public static class CreateLawyerCommandFromResAssembler
{
    public static CreateLawyerCommand ToCommandFromResource(LawyerRes resource)
    {
        return new CreateLawyerCommand(resource.Name, resource.Specialty);
    }
}