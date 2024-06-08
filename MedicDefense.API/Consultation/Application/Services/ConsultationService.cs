using MedicDefense.API.Consultation.Application.Interfaces;
using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Interfaces;

namespace MedicDefense.API.Consultation.Application.Services;

public class ConsultationService : IConsultationService
{
    private readonly IConsultRepository _consultRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly ILawyerRepository _lawyerRepository;

    public ConsultationService(IConsultRepository consultRepository, IDoctorRepository doctorRepository, ILawyerRepository lawyerRepository)
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

    public Consult GetConsult(int id)
    {
        var consult = _consultRepository.Get(id);
        
        if (consult == null)
        {
            throw new Exception("Consult not found");
        }
        
        return consult;
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
        
        existingConsult.Date = consult.Date;
        existingConsult.LegalIssue = consult.LegalIssue;
        existingConsult.Doctor = consult.Doctor;
        existingConsult.Lawyer = consult.Lawyer;
        
        _consultRepository.Update(existingConsult);
    }

    public void DeleteConsult(int id)
    {
        var consult = _consultRepository.Get(id);
        
        if (consult == null)
        {
            throw new Exception("Consult not found");
        }
        
        _consultRepository.Delete(id);
    }
}