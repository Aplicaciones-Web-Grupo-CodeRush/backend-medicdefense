namespace MedicDefense.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(
    string Name,
    string Email,
    string DNI,
    string ImageUrl,
    string Specialities,
    string PhoneNumber);