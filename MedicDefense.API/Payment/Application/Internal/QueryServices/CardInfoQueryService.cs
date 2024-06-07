using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Model.Queries;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;

namespace MedicDefense.API.Payment.Application.Internal.QueryServices;

public class CardInfoQueryService(ICardInfoRepository cardInfoRepository): ICardInfoQueryService
{
    public async Task<CardInfo?> Handle(GetCardInfoByIdQuery query)
    {
        return await cardInfoRepository.FindByIdAsync(query.CardInfoId);
    }
    public async Task<IEnumerable<CardInfo>> Handle(GetAllCardInfoQuery query)
    {
        return await cardInfoRepository.ListAsync();
    }
}