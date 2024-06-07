namespace MedicDefense.API.Payment.Interfaces.Resources;

public record PaymentInfoResource(int Id, string Description, PriceResource Price, CardInfoResource CardInfo);