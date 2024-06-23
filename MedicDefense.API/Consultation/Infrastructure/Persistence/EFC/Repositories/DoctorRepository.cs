using MedicDefense.API.Consultation.Domain;
using System.Collections.Generic;
using System.Linq;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace MedicDefense.API.Consultation.Infrastructure.Persistence.EFC.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _context;
    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }
    

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public Doctor Get(int id)
    {
        return _context.Doctors.FirstOrDefault(d => d.Id == id);
    }

    public void Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
    }

    public void Delete(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}