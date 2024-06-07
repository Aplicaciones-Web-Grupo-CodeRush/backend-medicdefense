using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Interfaces.Resources;
using Microsoft.OpenApi.Extensions;

namespace MedicDefense.API.Payment.Interfaces.Transform;

public class PriceResourceFromEntityAssembler{

public static PriceResource ToResourceFromEntity(Price entity)
{
    return new PriceResource(entity.Id, entity.Amount, entity.Type.GetDisplayName(), entity.MedicId,
        entity.LawyerId);
}
}