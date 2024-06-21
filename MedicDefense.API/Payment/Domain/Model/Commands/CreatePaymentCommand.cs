namespace MedicDefense.API.Payment.Domain.Model.Commands;

public record CreatePaymentCommand(string CardNumber, string ExpirationMonth, string ExpirationYear, string SecurityNumber, double Amount, long PayerId, long ReceiverId);