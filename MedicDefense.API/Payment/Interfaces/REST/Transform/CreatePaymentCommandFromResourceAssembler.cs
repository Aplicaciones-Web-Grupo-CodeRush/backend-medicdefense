using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Interfaces.REST.Resources;

namespace MedicDefense.API.Payment.Interfaces.REST.Transform;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(resource.CardNumber, resource.ExpirationMonth, resource.ExpirationYear,
            resource.SecurityNumber, resource.Amount, resource.PayerId, resource.ReceiverId);
    }
}