using MedicDefense.API.Consultation.Domain;

namespace MedicDefense.API.Consultation.Interfaces;

public interface ILawyerRepository
{
    void Add(Lawyer lawyer);
    Lawyer Get(int id);
    void Update(Lawyer lawyer);
    void Delete(int id);
}