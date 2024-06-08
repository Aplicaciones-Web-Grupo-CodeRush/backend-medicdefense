using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicDefense.API.Consultation.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly List<Doctor> _doctors = new List<Doctor>();

    public void Add(Doctor doctor)
    {
        _doctors.Add(doctor);
    }

    public Doctor Get(int id)
    {
        return _doctors.FirstOrDefault(d => d.Id == id);
    }

    public void Update(Doctor doctor)
    {
        var index = _doctors.FindIndex(d => d.Id == doctor.Id);
        if (index != -1)
        {
            _doctors[index] = doctor;
        }
    }

    public void Delete(int id)
    {
        var doctor = _doctors.FirstOrDefault(d => d.Id == id);
        if (doctor != null)
        {
            _doctors.Remove(doctor);
        }
    }
}