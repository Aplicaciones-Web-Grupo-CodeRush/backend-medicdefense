using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Commands;


namespace MedicDefense.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile> HandleCreateProfileCommand(CreateProfileCommand command);
    Task DeleteProfile(int id);
    
    Task<LawyersUsers> HandleCreateLawyersCommand(CreateLawyersCommand command);
}