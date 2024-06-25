using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Queries;

namespace MedicDefense.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile?> HandleGetProfileByIdQuery(GetProfileByIdQuery query);
    Task<IEnumerable<Profile>> GetAllProfilesAsync();
}