using MedicDefense.API.Consultation.Domain;

namespace MedicDefense.API.Consultation.Application.Interfaces;

public interface IConsultationService
{
    void CreateConsult(Consult consult);
    Consult GetConsult(int id);
    void UpdateConsult(Consult consult);
    void DeleteConsult(int id);
}