using MedicDefense.API.Profiles.Domain.Model.Commands;

namespace MedicDefense.API.Profiles.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string DNI { get; private set; }
    public string ImageUrl { get; private set; }
    public string Specialities { get; private set; }
    public string PhoneNumber { get; private set; }

    protected Profile()
    {
        this.Name = string.Empty;
        this.Email = string.Empty;
        this.DNI = string.Empty;
        this.ImageUrl = string.Empty;
        this.Specialities = string.Empty;
        this.PhoneNumber = string.Empty;
    }

    public Profile(CreateProfileCommand command)
    {

        this.Name = command.Name;
        this.Email = command.Email;
        this.DNI = command.DNI;
        this.ImageUrl = command.ImageUrl;
        this.Specialities = command.Specialities;
        this.PhoneNumber = command.PhoneNumber;
    }

    public void SetName(string name)
    {
        this.Name = name;
    }

    public void SetEmail(string email)
    {
        this.Email = email;
    }

    public void SetDNI(string dni)
    {
        this.DNI = dni;
    }

    public void SetImageUrl(string imageUrl)
    {
        this.ImageUrl = imageUrl;
    }

    public void SetSpecialities(string specialities)
    {
        this.Specialities = specialities;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        this.PhoneNumber = phoneNumber;
    }
}