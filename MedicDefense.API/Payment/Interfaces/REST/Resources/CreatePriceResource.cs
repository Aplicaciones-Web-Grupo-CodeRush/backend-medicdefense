namespace MedicDefense.API.Payment.Interfaces.Resources;

public record CreatePriceResource(double Amount, string Type, int MedicId, int LawyerId);