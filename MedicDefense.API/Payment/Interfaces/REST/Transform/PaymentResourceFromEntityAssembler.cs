using MedicDefense.API.Payment.Interfaces.REST.Resources;

namespace MedicDefense.API.Payment.Interfaces.REST.Transform;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Domain.Model.Aggregates.Payment entity)
    {
        return new PaymentResource(entity.Id, entity.CardNumber, entity.ExpirationMonth, entity.ExpirationYear,
            entity.SecurityNumber, entity.Amount, entity.PayerId, entity.ReceiverId);
    }
}