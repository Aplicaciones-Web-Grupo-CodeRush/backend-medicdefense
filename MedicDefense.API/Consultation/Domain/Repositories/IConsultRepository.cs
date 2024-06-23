using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;

namespace MedicDefense.API.Consultation.Domain.Repositories;

public interface IConsultRepository
{
    Task<Consult> FindByIdAsync(int id);
    void Add(Consult consult);
    Consult Get(int id);
    void Update(Consult consult);
    void Delete(int id);
    List<Consult> GetAll(); 
    
    Task SaveChangesAsync();
}