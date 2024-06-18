using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Model.Queries;
using MedicDefense.API.Consultation.Domain.Repositories;
using MedicDefense.API.Consultation.Domain.Services;
using MedicDefense.API.Consultation.Infrastructure.Persistence.EFC.Repositories;

namespace MedicDefense.API.Consultation.Application.QueryServices;

public class ConsultQueryService(IConsultRepository consultRepository): IConsultQueryService
{
    private readonly IConsultRepository _consultRepository;
    public async Task<Consult> Handle(GetConsultByIdQuery query)
    {
        return await consultRepository.FindByIdAsync(query.Id);
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
}