using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Commands;

namespace MedicDefense.API.Payment.Domain.Services;

public interface IPaymentInfoCommandService
{
    Task<PaymentInfo?> Handle(CreatePaymentInfoCommand command);
}