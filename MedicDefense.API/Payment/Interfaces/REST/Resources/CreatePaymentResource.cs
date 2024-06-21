namespace MedicDefense.API.Payment.Interfaces.REST.Resources;

public record CreatePaymentResource(string CardNumber, string ExpirationMonth, string ExpirationYear, string SecurityNumber, double Amount, long PayerId, long ReceiverId);