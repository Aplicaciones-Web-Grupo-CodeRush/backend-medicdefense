using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;

namespace MedicDefense.API.Consultation.Domain.Repositories;

public interface IDoctorRepository
{
    void Add(Doctor doctor);
    Doctor Get(int id);
    void Update(Doctor doctor);
    void Delete(int id);
    
    Task SaveChangesAsync();
}