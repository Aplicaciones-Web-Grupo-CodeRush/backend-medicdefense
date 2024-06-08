namespace MedicDefense.API.Payment.Interfaces.Resources;

public record CreatePaymentInfoResource(string Description, int PriceId, int CardInfoId);