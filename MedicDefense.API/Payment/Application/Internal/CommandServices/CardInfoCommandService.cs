using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Application.Internal.CommandServices;

public class CardInfoCommandService(ICardInfoRepository cardInfoRepository, IUnitOfWork unitOfWork) : ICardInfoCommandService
{
    public async Task<CardInfo?> Handle(CreateCardInfoCommand command)
    {
        var cardInfo = new CardInfo(command.CardNumber, command.SecurityNumber, command.CardHolderName);
        await cardInfoRepository.AddAsync(cardInfo); 
        await unitOfWork.CompleteAsync();
        return cardInfo;
    }
}