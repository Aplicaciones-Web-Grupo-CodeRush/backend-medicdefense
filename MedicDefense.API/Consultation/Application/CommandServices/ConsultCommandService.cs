using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Model.Commands;
using MedicDefense.API.Consultation.Domain.Services;
using MedicDefense.API.Consultation.Domain.Repositories;

namespace MedicDefense.API.Consultation.Application.CommandServices;

public class ConsultCommandService : IConsultCommandService
{
    private readonly IConsultRepository _consultRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly ILawyerRepository _lawyerRepository;

    public ConsultCommandService(IConsultRepository consultRepository, IDoctorRepository doctorRepository, ILawyerRepository lawyerRepository)
    {
        _consultRepository = consultRepository;
        _doctorRepository = doctorRepository;
        _lawyerRepository = lawyerRepository;
    }


    public void CreateConsult(Consult consult)
    {
        if (consult == null)
        {
            throw new ArgumentNullException(nameof(consult));
        }
        
        var doctor = _doctorRepository.Get(consult.Doctor.Id);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }
        
        var lawyer = _lawyerRepository.Get(consult.Lawyer.Id);
        if (lawyer == null)
        {
            throw new Exception("Lawyer not found");
        }
        
        _consultRepository.Add(consult);
    }

    public void CreateConsult(Doctor doctor)
    {
        if (doctor == null)
        {
            throw new ArgumentNullException(nameof(doctor));
        }

        _doctorRepository.Add(doctor);
    }

    public void UpdateConsult(Consult consult)
    {
        if (consult == null)
        {
            throw new ArgumentNullException(nameof(consult));
        }
        
        var existingConsult = _consultRepository.Get(consult.Id);
        if (existingConsult == null)
        {
            throw new Exception("Consult not found");
        }
        
        existingConsult.SetDate(consult.Date); 
        existingConsult.SetLegalIssue(consult.LegalIssue);
        existingConsult.SetDoctor(consult.Doctor);
        existingConsult.SetLawyer(consult.Lawyer); 
        
        _consultRepository.Update(existingConsult);    }

    public void DeleteConsult(int id)
    {
        var consult = _consultRepository.Get(id);
        
        if (consult == null)
        {
            throw new Exception("Consult not found");
        }
        
        _consultRepository.Delete(id);
    }

    public void AddDoctor(Doctor doctor)
    {
        if (doctor == null)
        {
            throw new ArgumentNullException(nameof(doctor));
        }

        _doctorRepository.Add(doctor);
    }

    public async Task<Consult> HandleCreateConsultCommand(CreateConsultCommand command)
    {
        var doctor = _doctorRepository.Get(command.Doctor.Id);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }

        var lawyer = _lawyerRepository.Get(command.Lawyer.Id);
        if (lawyer == null)
        {
            throw new Exception("Lawyer not found");
        }

        var consult = new Consult(command);
        _consultRepository.Add(consult);
        
        await _consultRepository.SaveChangesAsync();

        return await Task.FromResult(consult);
    }

    public async Task<Doctor> HandleCreateDoctorCommand(CreateDoctorCommand command)
    {
        var doctor = new Doctor(command);
        _doctorRepository.Add(doctor);

        await _doctorRepository.SaveChangesAsync();
        
        return await Task.FromResult(doctor);
    }

    public async Task<Lawyer> HandleCreateLawyerCommand(CreateLawyerCommand command)
    {
        var lawyer = new Lawyer(command);
        _lawyerRepository.Add(lawyer);
        
        await _lawyerRepository.SaveChangesAsync();

        return await Task.FromResult(lawyer);
    }
}