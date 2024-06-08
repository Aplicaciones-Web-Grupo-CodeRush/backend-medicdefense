using MedicDefense.API.Consultation.Domain;

namespace MedicDefense.API.Consultation.Interfaces;

public interface IDoctorRepository
{
    void Add(Doctor doctor);
    Doctor Get(int id);
    void Update(Doctor doctor);
    void Delete(int id);
}