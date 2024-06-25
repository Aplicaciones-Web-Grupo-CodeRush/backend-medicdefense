using MedicDefense.API.Consultation.Domain.Repositories;
using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Queries;
using MedicDefense.API.Profiles.Domain.Repositories;
using MedicDefense.API.Profiles.Domain.Services;

namespace MedicDefense.API.Profiles.Application.QueryServices;

public class ProfileQueryService : IProfileQueryService
{
    private readonly IProfileRepository _profileRepository;
    private readonly ILawyersRepository _lawyersRepository;

    public ProfileQueryService(IProfileRepository profileRepository, ILawyersRepository lawyersRepository)
    {
        _profileRepository = profileRepository;
        _lawyersRepository = lawyersRepository;
    }

    public async Task<Profile?> HandleGetProfileByIdQuery(GetProfileByIdQuery query)
    {
        return await _profileRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
        return await _profileRepository.ListAsync();
    }

    public async Task<LawyersUsers?> HandleGetLawyerByIdQuery(GetLawyersByIdQuery query)
    {
        return await _lawyersRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<LawyersUsers>> GetAllLawyersAsync()
    {
        return await _lawyersRepository.ListAsync();
    }
}