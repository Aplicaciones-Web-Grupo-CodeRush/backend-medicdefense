using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Interfaces.Resources;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class CreateCardInfoCommandFromResourceAssembler
{
    public static CreateCardInfoCommand ToCommandFromResource(CreateCardInfoResource resource)
    {
        return new CreateCardInfoCommand(resource.CardNumber, resource.SecurityNumber,
            resource.CardHolderName);
    }
}