using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Queries;
using MedicDefense.API.Profiles.Domain.Repositories;
using MedicDefense.API.Profiles.Domain.Services;

namespace MedicDefense.API.Profiles.Application.QueryServices;

public class ProfileQueryService : IProfileQueryService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileQueryService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Profile?> HandleGetProfileByIdQuery(GetProfileByIdQuery query)
    {
        return await _profileRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
        return await _profileRepository.ListAsync();
    }
}