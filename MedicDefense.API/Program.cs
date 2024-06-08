
using MedicDefense.API.LegalCase.Application.Internal.CommandServices;
using MedicDefense.API.LegalCase.Application.Internal.QueryServices;
using MedicDefense.API.LegalCase.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Services;
using MedicDefense.API.LegalCase.Infrastructure.Persistence.EFC.Repositories;

using MedicDefense.API.Educational.Application.Internal.CommandServices;
using MedicDefense.API.Educational.Application.Internal.QueryServices;
using MedicDefense.API.Educational.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Services;
using MedicDefense.API.Educational.Infrastructure.Persistence.EFC.Repositories;

using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(
    options =>
    {
        options.Conventions.Add(new KebabCaseRouteNamingConvention());   
    });

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ILegalCaseRepository, LegalCaseRepository>();
builder.Services.AddScoped<ILegalCaseQueryService, LegalCaseQueryService>();
builder.Services.AddScoped<ILegalCaseCommandService, LegalCaseCommandService>();

builder.Services.AddScoped<IEducationalResourceCommandService, EducationalResourceCommandService>();
builder.Services.AddScoped<IEducationalResourceQueryService, EducationalResourceQueryService>();
builder.Services.AddScoped<IEducationalResourceRepository, EducationalResourceRepository>();
var app = builder.Build();

// Verify Database objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();