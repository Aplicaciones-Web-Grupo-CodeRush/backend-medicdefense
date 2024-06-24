namespace MedicDefense.API.Profiles.Interfaces.REST.Resources;

public record ProfileRes(int Id, string Name, string Email, string DNI, string ImageUrl, string Specialities, string PhoneNumber);