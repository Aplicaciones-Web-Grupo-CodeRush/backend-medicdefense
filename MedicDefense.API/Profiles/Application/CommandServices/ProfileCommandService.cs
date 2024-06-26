using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Commands;
using MedicDefense.API.Profiles.Domain.Repositories;
using MedicDefense.API.Profiles.Domain.Services;
using MedicDefense.API.Shared.Domain.Repositories;

namespace MedicDefense.API.Profiles.Application.CommandServices;

public class ProfileCommandService : IProfileCommandService
{
    private readonly IProfileRepository _profileRepository;
    private readonly ILawyersRepository _lawyersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProfileCommandService(IProfileRepository profileRepository, ILawyersRepository lawyersRepository, IUnitOfWork unitOfWork)
    {
        _profileRepository = profileRepository;
        _lawyersRepository = lawyersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Profile> HandleCreateProfileCommand(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        await _profileRepository.AddAsync(profile);
        await _unitOfWork.CompleteAsync();
        return profile;
    }




    public async Task DeleteProfile(int id)
    {
        var profile = await _profileRepository.FindByIdAsync(id);
        if (profile != null)
        {
            _profileRepository.Remove(profile);
            await _unitOfWork.CompleteAsync();
        }
    }

    public async Task<LawyersUsers> HandleCreateLawyersCommand(CreateLawyersCommand command)
    {
        var lawyers = new LawyersUsers(command);
        await _lawyersRepository.AddAsync(lawyers);
        await _unitOfWork.CompleteAsync();
        return lawyers;    }
}