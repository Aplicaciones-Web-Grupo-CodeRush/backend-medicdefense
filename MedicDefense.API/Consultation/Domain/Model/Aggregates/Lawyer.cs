using MedicDefense.API.Consultation.Domain.Model.Commands;

namespace MedicDefense.API.Consultation.Domain.Model.Aggregates;

public class Lawyer
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Specialty { get; private set; }

    protected Lawyer()
    {
        this.Name = string.Empty;
        this.Specialty = string.Empty;
    }

    public Lawyer(CreateLawyerCommand command)
    {
        this.Name = command.Name;
        this.Specialty = command.Specialty;
    }
    public Lawyer(int id, string name, string specialty)
    {
        this.Id = id;
        this.Name = name;
        this.Specialty = specialty;
    }
}