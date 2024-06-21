using MedicDefense.API.IAM.Domain.Model.Aggregates;
using MedicDefense.API.IAM.Domain.Model.Commands;

namespace MedicDefense.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}