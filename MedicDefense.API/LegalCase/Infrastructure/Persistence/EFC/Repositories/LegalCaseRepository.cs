using MedicDefense.API.LegalCase.Domain.Model;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.LegalCase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.LegalCase.Infrastructure.Persistence.EFC.Repositories
{
    public class LegalCaseRepository : BaseRepository<Domain.Model.LegalCase>, ILegalCaseRepository
    {
        public LegalCaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Model.LegalCase>> FindByIdAsync(int id)
        {
            return await Context.Set<Domain.Model.LegalCase>()
                .Where(l => l.Id == id)
                .ToListAsync();
        }

        public async Task<Domain.Model.LegalCase> FindByCaseNumberAsync(string caseNumber)
        {
            return await Context.Set<Domain.Model.LegalCase>()
                .FirstOrDefaultAsync(l => l.CaseNumber == caseNumber);
        }

        public async Task<Domain.Model.LegalCase> FindByDescriptionAsync(string description)
        {
            return await Context.Set<Domain.Model.LegalCase>()
                .FirstOrDefaultAsync(l => l.Description == description);
        }

        public async Task<IEnumerable<Domain.Model.LegalCase>> FindByStatusAsync(string status)
        {
            return await Context.Set<Domain.Model.LegalCase>()
                .Where(l => l.Status == status)
                .ToListAsync();
        }
    }
}