using MedicDefense.API.Payment.Domain.Model.Commands;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Payment.Application.Internal.CommandServices;

public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork) : IPaymentCommandService
{
    public async Task<Domain.Model.Aggregates.Payment?> Handle(CreatePaymentCommand command)
    {
        var payments = new Domain.Model.Aggregates.Payment(command);
        await paymentRepository.AddAsync(payments);
        await unitOfWork.CompleteAsync();
        return payments;
    }
}