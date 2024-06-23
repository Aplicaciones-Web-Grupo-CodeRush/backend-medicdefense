using MedicDefense.API.Consultation.Domain.Model.Commands;

namespace MedicDefense.API.Consultation.Domain.Model.Aggregates;

public class Doctor
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Specialty { get; private set; }

    protected Doctor()
    {
        this.Name = string.Empty;
        this.Specialty = string.Empty;
    }

    public Doctor(CreateDoctorCommand command)
    {
        this.Name = command.Name;
        this.Specialty = command.Specialty;
    }
    public Doctor(int id, string name, string specialty)
    {
        this.Id = id;
        this.Name = name;
        this.Specialty = specialty;
    }
}