using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Model.Entities;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPriceCommandService
{
    Task<Price?> Handle(CreatePriceCommand command);
}