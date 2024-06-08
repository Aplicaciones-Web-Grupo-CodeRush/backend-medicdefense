using MedicDefense.API.Payment.Application.Internal.CommandServices;
using MedicDefense.API.Payment.Application.Internal.QueryServices;
using MedicDefense.API.Payment.Domain.Repositories;
using MedicDefense.API.Payment.Domain.Services;
using MedicDefense.API.Payment.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.Shared.Domain.Repositories;
using MedicDefense.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Conventions.Add(new KebabCaseRouteNamingConvention());   
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "MedicDefense.API",
                Version = "v1",
                Description = "MedicDefense.API REST API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Learning Center",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Database Connection String
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

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Resources Bounded Context Injection Configuration
builder.Services.AddScoped<IPaymentInfoCommandService, PaymentInfoCommandService>();
builder.Services.AddScoped<IPaymentInfoQueryService, PaymentInfoQueryService>();
builder.Services.AddScoped<IPaymentInfoRepository, PaymentInfoRepository>();
/*builder.Services.AddScoped<IPriceCommandService, PriceCommandService>();
builder.Services.AddScoped<IPriceQueryService, PriceQueryService>();
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<ICardInfoCommandService, CardInfoCommandService>();
builder.Services.AddScoped<ICardInfoQueryService, CardInfoQueryService>();
builder.Services.AddScoped<ICardInfoRepository, CardInfoRepository>();*/

var app = builder.Build();

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