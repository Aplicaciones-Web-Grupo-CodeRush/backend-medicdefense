using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.ValueObjects;

namespace MedicDefense.API.Payment.Domain.Model.Entities;

public class CardInfo
{
    public int Id { get; private set; }
    public string CardNumber { get; private set; }
    public string SecurityNumber { get; private set; }
    public ExpirationDate ExpirationDate { get; private set; }
    public string CardHolderName { get; private set; }

    public CardInfo()
    {
        CardNumber= string.Empty;
        SecurityNumber = string.Empty;
        ExpirationDate = new ExpirationDate(0, 0);
        CardHolderName = string.Empty;
    }
    public CardInfo(string cardNumber, 
        string securityNumber, 
        string cardHolderName, 
        int month, 
        int year)
    {
        CardNumber= cardNumber;
        SecurityNumber = securityNumber;
        ExpirationDate = new ExpirationDate(month, year);
        CardHolderName = cardHolderName;
    }
    
    public CardInfo(CreateCardInfoCommand command)
    {
        CardNumber= command.CardNumber;
        SecurityNumber = command.SecurityNumber;
        ExpirationDate = new ExpirationDate(command.Month, command.Year);
        CardHolderName = command.CardHolderName;
    }
    public ICollection<PaymentInfo> PaymentInfos { get; }
}