using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;

namespace MedicDefense.API.Payment.Application.Internal.QueryServices;

public class PriceQueryService(IPriceRepository priceRepository): IPriceQueryService
{
    public async Task<IEnumerable<Price>> Handle(GetAllPriceByLawyerIdQuery query)
    {
        return await priceRepository.FindAllByLawyerIdAsync(query.LawyerId);
    }
    public async Task<IEnumerable<Price>> Handle(GetAllPriceByMedicIdQuery query)
    {
        return await priceRepository.FindAllByMedicIdAsync(query.MedicId);
    }
    public async Task<Price?> Handle(GetPriceByIdQuery query)
    {
        return await priceRepository.FindByIdAsync(query.PriceId);
    }
}