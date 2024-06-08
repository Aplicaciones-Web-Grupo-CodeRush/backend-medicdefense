using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicDefense.API.Consultation.Infrastructure.Repositories;

public class LawyerRepository : ILawyerRepository
{
    private readonly List<Lawyer> _lawyers = new List<Lawyer>();

    public void Add(Lawyer lawyer)
    {
        _lawyers.Add(lawyer);
    }

    public Lawyer Get(int id)
    {
        return _lawyers.FirstOrDefault(l => l.Id == id);
    }

    public void Update(Lawyer lawyer)
    {
        var index = _lawyers.FindIndex(l => l.Id == lawyer.Id);
        if (index != -1)
        {
            _lawyers[index] = lawyer;
        }
    }

    public void Delete(int id)
    {
        var lawyer = _lawyers.FirstOrDefault(l => l.Id == id);
        if (lawyer != null)
        {
            _lawyers.Remove(lawyer);
        }
    }
}