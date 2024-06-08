using MedicDefense.API.Consultation.Domain;

namespace MedicDefense.API.Consultation.Interfaces;

public interface IConsultRepository
{
    void Add(Consult consult);
    Consult Get(int id);
    void Update(Consult consult);
    void Delete(int id);
}