using MedicDefense.API.Payment.Domain.Model.ValueObjects;

namespace MedicDefense.API.Payment.Domain.Model.Commands;

public record CreatePriceCommand(double Amount, ECurrencyType Type, int MedicId, int LawyerId);