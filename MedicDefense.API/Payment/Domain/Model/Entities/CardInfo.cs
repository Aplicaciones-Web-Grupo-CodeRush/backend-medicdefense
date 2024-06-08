using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.ValueObjects;

namespace MedicDefense.API.Payment.Domain.Model.Entities;

public class CardInfo
{
    public int Id { get; private set; }
    public string CardNumber { get; private set; }
    public string SecurityNumber { get; private set; }
    public string CardHolderName { get; private set; }

    public CardInfo()
    {
        CardNumber= string.Empty;
        SecurityNumber = string.Empty;
        CardHolderName = string.Empty;
    }
    public CardInfo(string cardNumber, 
        string securityNumber, 
        string cardHolderName)
    {
        CardNumber= cardNumber;
        SecurityNumber = securityNumber;
        CardHolderName = cardHolderName;
    }
    
    public CardInfo(CreateCardInfoCommand command)
    {
        CardNumber= command.CardNumber;
        SecurityNumber = command.SecurityNumber;
        CardHolderName = command.CardHolderName;
    }
    public ICollection<PaymentInfo> PaymentInfos { get; }
}