using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace MedicDefense.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class LawyersRepository(AppDbContext context) : BaseRepository<LawyersUsers>(context), ILawyersRepository
{
    
}