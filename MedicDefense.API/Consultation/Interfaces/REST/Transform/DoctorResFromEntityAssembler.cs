using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;

namespace MedicDefense.API.Consultation.Interfaces.REST.Transform;

public static class DoctorResFromEntityAssembler
{
    public static DoctorRes ToResourceFromEntity(Doctor entity)
    {
        return new DoctorRes(entity.Id, entity.Name, entity.Specialty);
    }
}