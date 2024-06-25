using MedicDefense.API.Profiles.Domain.Model.Commands;

namespace MedicDefense.API.Profiles.Domain.Model.Aggregates;

public class LawyersUsers
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int YearsOfExperience { get; private set; }
    public string Specialization { get; private set; }
    public string UrlToImage { get; private set; }
    public int CasesWon { get; private set; }
    public decimal Price { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }

    protected LawyersUsers()
    {
        this.Name = string.Empty;
        this.Email = string.Empty;
        this.PhoneNumber = string.Empty;
        this.Specialization = string.Empty;
        this.UrlToImage = string.Empty;
    }

    public LawyersUsers(CreateLawyersCommand command)
    {
        this.Name = command.Name;
        this.YearsOfExperience = command.YearsOfExperience;
        this.Specialization = command.Specialization;
        this.UrlToImage = command.UrlToImage;
        this.CasesWon = command.CasesWon;
        this.Price = command.Price;
        this.Email = command.Email;
        this.PhoneNumber = command.PhoneNumber;
    }
}