using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Interfaces.REST.Resources;

namespace MedicDefense.API.Consultation.Interfaces.REST.Transform;

public static class ConsultResFromEntityAssembler
{
    public static ConsultRes ToResourceFromEntity(Consult consult)
    {
        DoctorRes doctorRes = null;
        if (consult.Doctor != null)
        {
            doctorRes = new DoctorRes(consult.Doctor.Id, consult.Doctor.Name, consult.Doctor.Specialty);
        }

        LawyerRes lawyerRes = null;
        if (consult.Lawyer != null)
        {
            lawyerRes = new LawyerRes(consult.Lawyer.Id, consult.Lawyer.Name, consult.Lawyer.Specialty);
        }

        return new ConsultRes(consult.Id, consult.Date, consult.LegalIssue, doctorRes, lawyerRes);
    }
}