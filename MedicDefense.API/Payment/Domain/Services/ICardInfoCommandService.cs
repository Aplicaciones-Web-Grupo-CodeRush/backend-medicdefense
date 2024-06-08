using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Entities;

namespace MedicDefense.API.Payment.Domain.Services;

public interface ICardInfoCommandService
{
    Task<CardInfo?> Handle(CreateCardInfoCommand command);
}