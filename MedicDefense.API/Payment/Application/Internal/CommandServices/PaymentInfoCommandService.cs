using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Application.Internal.CommandServices;

public class PaymentInfoCommandService(IPaymentInfoRepository paymentInfoRepository, IPriceRepository priceRepository, ICardInfoRepository cardInfoRepository, IUnitOfWork unitOfWork) : IPaymentInfoCommandService
{
    public async Task<PaymentInfo?> Handle(CreatePaymentInfoCommand command)
    {
        var paymentInfo = new PaymentInfo(command.CardInfoId, command.PriceId, command.Description);
        await paymentInfoRepository.AddAsync(paymentInfo); 
        await unitOfWork.CompleteAsync();
        var cardInfo = await cardInfoRepository.FindByIdAsync(command.CardInfoId);
        var price = await priceRepository.FindByIdAsync(command.PriceId);
        paymentInfo.CardInfo = cardInfo;
        paymentInfo.Price = price;
        return paymentInfo;
    }
}