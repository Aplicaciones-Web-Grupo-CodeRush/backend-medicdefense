using System.ComponentModel.DataAnnotations.Schema;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using MedicDefense.API.Payment.Domain.Model.Aggregates;
using MedicDefense.API.Payment.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
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

        // Place here your entities configuration
        /*builder.Entity<PaymentInfo>().ToTable("payments");
        builder.Entity<PaymentInfo>().HasKey(p => p.Id);
        builder.Entity<PaymentInfo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PaymentInfo>().Property(l => l.Description).IsRequired();

        /*builder.Entity<Price>().ToTable("prices");
        builder.Entity<Price>().HasKey(p => p.Id);
        builder.Entity<Price>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Price>().Property(p => p.Amount).IsRequired();
        builder.Entity<Price>().Property(p => p.Type).IsRequired();
        builder.Entity<Price>().Property(p => p.MedicId).IsRequired();
        builder.Entity<Price>().Property(p => p.LawyerId).IsRequired();

        builder.Entity<CardInfo>().ToTable("cards");
        builder.Entity<CardInfo>().HasKey(c => c.Id);
        builder.Entity<CardInfo>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CardInfo>().Property(c => c.CardNumber).IsRequired();
        builder.Entity<CardInfo>().Property(c => c.SecurityNumber).IsRequired();

        // Price Relationships
        builder.Entity<Price>()
            .HasMany(p => p.PaymentInfos)
            .WithOne(i => i.Price)
            .HasForeignKey(i => i.PriceId)
            .HasPrincipalKey(p => p.Id);

        builder.Entity<CardInfo>()
            .HasMany(c => c.PaymentInfos)
            .WithOne(p => p.CardInfo)
            .HasForeignKey(i => i.CardInfoId)
            .HasPrincipalKey(p => p.Id);*/
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}