using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Interfaces.Resources;
using MedicDefense.API.Payment.Domain.Model.ValueObjects;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class CreatePriceCommandFromResourceAssembler
{
    public static CreatePriceCommand ToCommandFromResource(CreatePriceResource resource)
    {
        return new CreatePriceCommand(resource.Amount,resource.Type.ToEnum<ECurrencyType>(),resource.MedicId, resource.LawyerId);
    }
}