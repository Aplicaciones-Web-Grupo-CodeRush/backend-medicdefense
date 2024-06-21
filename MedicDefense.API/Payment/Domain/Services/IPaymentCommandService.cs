using MedicDefense.API.Payment.Domain.Model.Commands;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPaymentCommandService
{
    Task<Model.Aggregates.Payment?> Handle(CreatePaymentCommand command);
}