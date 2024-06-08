using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Interfaces.Resources;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class CardInfoResourceFromEntityAssembler
{
    public static CardInfoResource ToResourceFromEntity(CardInfo entity)
    {
        return new CardInfoResource(entity.Id, entity.CardNumber, entity.SecurityNumber, entity.CardHolderName);
    }
}