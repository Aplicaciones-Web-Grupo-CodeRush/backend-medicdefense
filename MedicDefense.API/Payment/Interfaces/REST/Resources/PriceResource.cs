namespace MedicDefense.API.Payment.Interfaces.Resources;

public record PriceResource(int Id, double Amount, string Type, int MedicId, int LawyerId);