namespace MedicDefense.API.Profiles.Interfaces.REST.Resources;

public record CreateProfileRes(string Name, string Email, string DNI, string ImageUrl, string Specialities, string PhoneNumber);