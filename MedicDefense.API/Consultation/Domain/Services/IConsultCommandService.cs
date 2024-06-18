using MedicDefense.API.Consultation.Domain.Model.Commands;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;

namespace MedicDefense.API.Consultation.Domain.Services;

public interface IConsultCommandService
{
    void CreateConsult(Consult consult);
    void UpdateConsult(Consult consult);
    void DeleteConsult(int id);
    void AddDoctor(Doctor doctor);

    Task<Consult> HandleCreateConsultCommand(CreateConsultCommand command);
    Task<Doctor> HandleCreateDoctorCommand(CreateDoctorCommand command);
    Task<Lawyer> HandleCreateLawyerCommand(CreateLawyerCommand command);
}