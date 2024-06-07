using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Model.Queries;

namespace MedicDefense.API.Payment.Domain.Services;

public interface ICardInfoQueryService
{
    Task<CardInfo?> Handle(GetCardInfoByIdQuery query);
    Task<IEnumerable<CardInfo>> Handle(GetAllCardInfoQuery query);
}