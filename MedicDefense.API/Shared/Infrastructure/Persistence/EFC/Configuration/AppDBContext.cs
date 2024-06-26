using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

using MedicDefense.API.Communication.Domain.Model.Aggregates;

using MedicDefense.API.Communication.Domain.Model.Aggregates;
using MedicDefense.API.Consultation.Domain.Model.Aggregates;
using MedicDefense.API.Educational.Domain.Model.Aggregates;
using MedicDefense.API.Profiles.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<Doctor> Doctors { get; set; } 
    public DbSet<Lawyer> Lawyers { get; set; }
    
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<LawyersUsers> LawyersUsers { get; set; }

    
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

        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().ToTable("Payments");
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().HasKey(p => p.Id);
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.CardNumber).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.ExpirationMonth).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.ExpirationYear).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.SecurityNumber).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.Amount).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.PayerId).IsRequired();
        builder.Entity<Payment.Domain.Model.Aggregates.Payment>().Property(p => p.ReceiverId).IsRequired();
        
        builder.Entity<Consult>().ToTable("Consults");
        builder.Entity<Consult>().HasKey(c => c.Id);
        builder.Entity<Consult>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Consult>().HasOne(c => c.Doctor).WithMany();
        builder.Entity<Consult>().HasOne(c => c.Lawyer).WithMany();


        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Doctor>().Property(d => d.Name).IsRequired();
        builder.Entity<Doctor>().Property(d => d.Specialty).IsRequired();
        
        builder.Entity<Lawyer>().ToTable("Lawyers");
        builder.Entity<Lawyer>().HasKey(l => l.Id);
        builder.Entity<Lawyer>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Lawyer>().Property(l => l.Name).IsRequired();
        builder.Entity<Lawyer>().Property(l => l.Specialty).IsRequired();
        
        builder.Entity<Profile>().ToTable("Profiles");
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.Name).IsRequired();
        builder.Entity<Profile>().Property(p => p.Email).IsRequired();
        builder.Entity<Profile>().Property(p => p.DNI).IsRequired();
        builder.Entity<Profile>().Property(p => p.ImageUrl).IsRequired();
        builder.Entity<Profile>().Property(p => p.Specialities).IsRequired();
        builder.Entity<Profile>().Property(p => p.PhoneNumber).IsRequired();
        
        
        builder.Entity<LawyersUsers>().ToTable("LawyersUsers");
        builder.Entity<LawyersUsers>().HasKey(l => l.Id);
        builder.Entity<LawyersUsers>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<LawyersUsers>().Property(l => l.Name).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.YearsOfExperience).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.Specialization).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.UrlToImage).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.CasesWon).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.Price).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.Email).IsRequired();
        builder.Entity<LawyersUsers>().Property(l => l.PhoneNumber).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
    }
}