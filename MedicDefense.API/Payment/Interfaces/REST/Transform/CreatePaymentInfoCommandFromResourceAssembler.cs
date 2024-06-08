using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Interfaces.Resources;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class CreatePaymentInfoCommandFromResourceAssembler
{
    public static CreatePaymentInfoCommand ToCommandFromResource(CreatePaymentInfoResource resource)
    {
        return new CreatePaymentInfoCommand(resource.Description,resource.PriceId,resource.CardInfoId);
    }
}