namespace MedicDefense.API.Profiles.Interfaces.REST.Resources;

public record CreateLawyersRes(
    string Name,
    int YearsOfExperience,
    string Specialization,
    string UrlToImage,
    int CasesWon,
    decimal Price,
    string Email,
    string PhoneNumber
);