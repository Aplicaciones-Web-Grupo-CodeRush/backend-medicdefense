using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Entities;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Application.Internal.CommandServices;

public class PriceCommandService(IPriceRepository priceRepository, IUnitOfWork unitOfWork) : IPriceCommandService
{
    public async Task<Price?> Handle(CreatePriceCommand command)
    {
        var price = new Price(command.Amount,  command.Type,command.MedicId, command.LawyerId);
        await priceRepository.AddAsync(price); 
        await unitOfWork.CompleteAsync();
        return price;
    }
}