using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;

namespace MedicDefense.API.Consultation.Domain.Repositories;

public interface ILawyerRepository
{
    void Add(Lawyer lawyer);
    Lawyer Get(int id);
    void Update(Lawyer lawyer);
    void Delete(int id);
    
    Task SaveChangesAsync();
}