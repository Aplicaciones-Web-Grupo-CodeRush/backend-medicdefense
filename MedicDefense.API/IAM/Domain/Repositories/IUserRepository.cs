using MedicDefense.API.IAM.Domain.Model.Aggregates;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}