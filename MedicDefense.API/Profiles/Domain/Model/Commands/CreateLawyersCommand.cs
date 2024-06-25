namespace MedicDefense.API.Profiles.Domain.Model.Commands;

public record CreateLawyersCommand(
    string Name,
    int YearsOfExperience,
    string Specialization,
    string UrlToImage,
    int CasesWon,
    decimal Price,
    string Email,
    string PhoneNumber);