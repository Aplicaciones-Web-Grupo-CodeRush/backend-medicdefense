using MedicDefense.API.Consultation.Domain;
using System.Collections.Generic;
using System.Linq;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace MedicDefense.API.Consultation.Infrastructure.Persistence.EFC.Repositories;

public class LawyerRepository : ILawyerRepository
{
    private readonly AppDbContext _context;
    public LawyerRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Lawyer lawyer)
    {
        _context.Lawyers.Add(lawyer);
    }

    public Lawyer Get(int id)
    {
        return _context.Lawyers.FirstOrDefault(l => l.Id == id);
    }

    public void Update(Lawyer lawyer)
    {
        _context.Lawyers.Update(lawyer);
    }

    public void Delete(int id)
    {
        var lawyer = _context.Lawyers.FirstOrDefault(l => l.Id == id);
        if (lawyer != null)
        {
            _context.Lawyers.Remove(lawyer);
        }
    }

    public  async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();    
    }
}