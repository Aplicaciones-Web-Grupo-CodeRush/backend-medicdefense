using MedicDefense.API.Consultation.Domain;
using MedicDefense.API.Consultation.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Consultation.Infrastructure.Persistence.EFC.Repositories;

public class ConsultRepository : BaseRepository<Consult>, IConsultRepository
{
    public ConsultRepository(AppDbContext context) : base(context)
    {
    }    
    
    public new async Task<Consult?> FindByIdAsync(int id)
    {
        return await Context.Set<Consult>()
            .Include(c => c.Doctor)
            .Include(c => c.Lawyer)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    
    
    public void Add(Consult consult)
    {
        // Verificar si el contexto ya está rastreando la entidad Doctor
        var trackedDoctor = Context.Doctors.Local.FirstOrDefault(d => d.Id == consult.Doctor.Id);
        if (trackedDoctor != null)
        {
            // Sincronizar la entidad existente
            Context.Entry(trackedDoctor).CurrentValues.SetValues(consult.Doctor);
            consult.SetDoctor(trackedDoctor); // Usar la entidad existente
        }
        else
        {
            // Verificar si la entidad ya existe en la base de datos
            var existingDoctor = Context.Doctors.Find(consult.Doctor.Id);
            if (existingDoctor != null)
            {
                // Adjuntar entidad existente
                Context.Entry(existingDoctor).State = EntityState.Detached;
                consult.SetDoctor(existingDoctor); // Usar la entidad existente
            }
            else
            {
                Context.Doctors.Attach(consult.Doctor); // Adjuntar la nueva entidad
            }
        }

        // Verificar si el contexto ya está rastreando la entidad Lawyer
        var trackedLawyer = Context.Lawyers.Local.FirstOrDefault(l => l.Id == consult.Lawyer.Id);
        if (trackedLawyer != null)
        {
            // Sincronizar la entidad existente
            Context.Entry(trackedLawyer).CurrentValues.SetValues(consult.Lawyer);
            consult.SetLawyer(trackedLawyer); // Usar la entidad existente
        }
        else
        {
            // Verificar si la entidad ya existe en la base de datos
            var existingLawyer = Context.Lawyers.Find(consult.Lawyer.Id);
            if (existingLawyer != null)
            {
                // Adjuntar entidad existente
                Context.Entry(existingLawyer).State = EntityState.Detached;
                consult.SetLawyer(existingLawyer); // Usar la entidad existente
            }
            else
            {
                Context.Lawyers.Attach(consult.Lawyer); // Adjuntar la nueva entidad
            }
        }

        // Añadir la consulta
        Context.Set<Consult>().Add(consult);
    }


    public Consult? Get(int id)
    {
        return Context.Set<Consult>()
            .Include(c => c.Doctor)
            .Include(c => c.Lawyer)
            .FirstOrDefault(c => c.Id == id);
    }

    public void Update(Consult consult)
    {
        Context.Set<Consult>().Update(consult);
    }

    public void Delete(int id)
    {
        var consult = Context.Set<Consult>().FirstOrDefault(c => c.Id == id);
        if (consult != null)
        {
            Context.Set<Consult>().Remove(consult);
        }
    }
    
    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}