using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicDefense.API.Consultation.Infrastructure.Repositories;

public class ConsultRepository : IConsultRepository
{
    private readonly List<Consult> _consults = new List<Consult>();
    
    public void Add(Consult consult)
    {
        _consults.Add(consult);
    }

    public Consult Get(int id)
    {
        return _consults.FirstOrDefault(c => c.Id == id);
    }

    public void Update(Consult consult)
    {
        var index = _consults.FindIndex(c => c.Id == consult.Id);
        if (index != -1)
        {
            _consults[index] = consult;
        }
    }

    public void Delete(int id)
    {
        var consult = _consults.FirstOrDefault(c => c.Id == id);
        if (consult != null)
        {
            _consults.Remove(consult);
        }
    }
}