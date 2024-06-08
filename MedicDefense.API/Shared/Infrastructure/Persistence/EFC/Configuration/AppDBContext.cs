using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

using MedicDefense.API.Communication.Domain.Model.Aggregates;

using MedicDefense.API.Educational.Domain.Model.Aggregates;

using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
  
        // Communication Context
        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().OwnsOne(n => n.Information,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(i => i.Information).HasColumnName("Information");
            });

        builder.Entity<LegalCase.Domain.Model.LegalCase>().ToTable("LegalCases");
        builder.Entity<LegalCase.Domain.Model.LegalCase>().HasKey(l => l.Id);
        builder.Entity<LegalCase.Domain.Model.LegalCase>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<LegalCase.Domain.Model.LegalCase>().Property(l => l.CaseNumber).IsRequired();
        builder.Entity<LegalCase.Domain.Model.LegalCase>().Property(l => l.Description).IsRequired();
        builder.Entity<LegalCase.Domain.Model.LegalCase>().Property(l => l.Status).IsRequired();

        builder.Entity<EducationalResource>().ToTable("EducationalResources");
        builder.Entity<EducationalResource>().HasKey(f => f.Id);
        builder.Entity<EducationalResource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EducationalResource>().Property(f => f.Title).IsRequired();
        builder.Entity<EducationalResource>().Property(f => f.Author).IsRequired();
        builder.Entity<EducationalResource>().Property(f => f.ContentType).IsRequired();
        builder.Entity<EducationalResource>().Property(f => f.VideoUrl).IsRequired();
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
    }
}