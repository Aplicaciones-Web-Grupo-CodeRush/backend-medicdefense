using MedicDefense.API.Payment.Domain.Model.Commands;

namespace MedicDefense.API.Payment.Domain.Model.Aggregates;

public partial class Payment
{
    public int Id { get; }
    public string CardNumber { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string SecurityNumber { get; set; }
    public double Amount { get; set; }
    public long PayerId { get; private set; }
    public long ReceiverId { get; private set; }

    public Payment()
    {
        CardNumber = string.Empty;
        ExpirationMonth = string.Empty;
        ExpirationYear = string.Empty;
        SecurityNumber = string.Empty;
        Amount = 0;
        PayerId = 0;
        ReceiverId = 0;
    }
    public Payment(string cardNumber, string expirationMonth, string expirationYear, string securityNumber, double amount, long payerId, long receiverId)
    {
        CardNumber = cardNumber;
        ExpirationMonth = expirationMonth;
        ExpirationYear = expirationYear;
        SecurityNumber = securityNumber;
        Amount = amount;
        PayerId = payerId;
        ReceiverId = receiverId;
    }
    public Payment(CreatePaymentCommand command)
    {
        CardNumber = command.CardNumber;
        ExpirationMonth = command.ExpirationMonth;
        ExpirationYear = command.ExpirationYear;
        SecurityNumber = command.SecurityNumber;
        Amount = command.Amount;
        PayerId = command.PayerId;
        ReceiverId = command.ReceiverId;
    }
}