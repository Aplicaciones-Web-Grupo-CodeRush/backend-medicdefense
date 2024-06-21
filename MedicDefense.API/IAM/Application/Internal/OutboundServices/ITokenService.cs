using MedicDefense.API.IAM.Domain.Model.Aggregates;

namespace MedicDefense.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}