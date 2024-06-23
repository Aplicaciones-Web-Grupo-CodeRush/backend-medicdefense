using MedicDefense.API.Consultation.Domain.Model.Commands;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;

namespace MedicDefense.API.Consultation.Interfaces.REST.Transform;

public static class CreateDoctorCommandFromResAssembler
{
    public static CreateDoctorCommand ToCommandFromResource(DoctorRes resource)
    {
        return new CreateDoctorCommand( resource.Name, resource.Specialty);
    }
}