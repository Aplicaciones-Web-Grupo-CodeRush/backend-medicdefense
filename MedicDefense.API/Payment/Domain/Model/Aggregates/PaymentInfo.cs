using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Payment.Domain.Model.Aggregates;

public class PaymentInfo
{
    public int Id { get; }
    
    public Price Price { get; set; }
    public CardInfo CardInfo { get; set; }
    public int PriceId { get; private set; }
    
    public string Description { get; private set; }
    
    public int CardInfoId { get; private set; }

    public PaymentInfo()
    {
        PriceId = 0;
        Description = string.Empty;
        CardInfoId = 0;
    }
    public PaymentInfo(int cardInfoId, int priceId, string description)
    {
        CardInfoId = cardInfoId;
        PriceId = priceId;
        Description = description;
    }
    public PaymentInfo(CreatePaymentInfoCommand command)
    {
        CardInfoId = command.CardInfoId;
        PriceId = command.PriceId;
        Description = command.Description;
    }
}