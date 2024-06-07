using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Interfaces.Resources;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class PaymentInfoResourceFromEntityAssembler
{

    public static PaymentInfoResource ToResourceFromEntity(PaymentInfo entity)
    {
        return new PaymentInfoResource(entity.Id, entity.Description,
            PriceResourceFromEntityAssembler.ToResourceFromEntity(entity.Price), 
            CardInfoResourceFromEntityAssembler.ToResourceFromEntity(entity.CardInfo));
    }
}