using MedicDefense.API.IAM.Domain.Model.Aggregates;
using MedicDefense.API.IAM.Domain.Model.Queries;

namespace MedicDefense.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}