namespace MedicDefense.API.Payment.Domain.Model.Commands;

public record  CreatePaymentInfoCommand (string Description, int PriceId, int CardInfoId);