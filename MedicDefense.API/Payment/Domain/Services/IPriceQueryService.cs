using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Model.Queries;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPriceQueryService
{
    Task<Price?> Handle(GetPriceByIdQuery query);
    Task<IEnumerable<Price>> Handle(GetAllPriceByLawyerIdQuery query);
    Task<IEnumerable<Price>> Handle(GetAllPriceByMedicIdQuery query);
}