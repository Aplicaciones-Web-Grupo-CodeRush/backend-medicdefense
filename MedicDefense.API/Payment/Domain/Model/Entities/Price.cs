using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.ValueObjects;
using MedicDefense.API.Payment.Domain.Model.Aggregates;

namespace MedicDefense.API.Payment.Domain.Model.Entities;

public class Price
{
    public int Id { get; set; }
    public int LawyerId { get; private set; }
    public int MedicId { get; private set; }
    public ECurrencyType Type { get; protected set; }
    public double Amount { get; private set; }
    public Price(double amount)
    {
        Amount = amount;
        Type = ECurrencyType.Usd;
        LawyerId = 0;
        MedicId = 0;
    }
    public Price(double amount, ECurrencyType type, int medicId, int lawyerId)
    {
        Amount = amount;
        Type = type;
        LawyerId = lawyerId;
        MedicId = medicId;
    }
    public Price(CreatePriceCommand command)
    {
        Amount = command.Amount;
        Type = command.Type;
        LawyerId = command.LawyerId;
        MedicId = command.MedicId;
    }

    public void Sol() { Type = ECurrencyType.Pen; }
    public void Pound() { Type = ECurrencyType.Gbp; }
    public void Euro() { Type = ECurrencyType.Eur; }
    public void Yen() { Type = ECurrencyType.Jpy; }
    public void Ruble() { Type = ECurrencyType.Rub; }
    public void CanadaDollar() { Type = ECurrencyType.Cad; }
    public void HongKongDollar() { Type = ECurrencyType.Hkd; }
    public void NeoZealandDollar() { Type = ECurrencyType.Nzd; }
    public void MexicanPeso() { Type = ECurrencyType.Mxn; }
    public void Renminbi() { Type = ECurrencyType.Cny; }
    public void IndianRupie() { Type = ECurrencyType.Inr; }
    
    public ICollection<PaymentInfo> PaymentInfos { get; }
}