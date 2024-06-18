using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Model.Queries;

namespace MedicDefense.API.Consultation.Domain.Services;

public interface IConsultQueryService
{
    Consult GetConsult(int id);
    Task<Consult> Handle(GetConsultByIdQuery query);
}