

using MedicDefense.API.Consultation.Infrastructure.Persistence.EFC.Repositories;

using MedicDefense.API.Consultation.Application.CommandServices;
using MedicDefense.API.Consultation.Application.QueryServices;
using MedicDefense.API.Consultation.Domain.Repositories;
using MedicDefense.API.Consultation.Domain.Services;

using MedicDefense.API.Consultation.Interfaces;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;


using MedicDefense.API.Communication.Application.Internal.CommandServices;
using MedicDefense.API.Communication.Application.Internal.QueryServices;
using MedicDefense.API.Communication.Domain.Repositories;
using MedicDefense.API.Communication.Domain.Services;
using MedicDefense.API.Communication.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.Communication.Interfaces.ACL;
using MedicDefense.API.Communication.Interfaces.ACL.Services;


using MedicDefense.API.LegalCase.Application.Internal.CommandServices;
using MedicDefense.API.LegalCase.Application.Internal.QueryServices;
using MedicDefense.API.LegalCase.Domain.Repositories;
using MedicDefense.API.LegalCase.Domain.Services;
using MedicDefense.API.LegalCase.Infrastructure.Persistence.EFC.Repositories;

using MedicDefense.API.Profiles.Application.CommandServices;
using MedicDefense.API.Profiles.Application.QueryServices;
using MedicDefense.API.Profiles.Domain.Repositories;
using MedicDefense.API.Profiles.Domain.Services;
using MedicDefense.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

using MedicDefense.API.Educational.Application.Internal.CommandServices;
using MedicDefense.API.Educational.Application.Internal.QueryServices;
using MedicDefense.API.Educational.Domain.Repositories;
using MedicDefense.API.Educational.Domain.Services;
using MedicDefense.API.Educational.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.IAM.Application.Internal.CommandServices;
using MedicDefense.API.IAM.Application.Internal.OutboundServices;
using MedicDefense.API.IAM.Application.Internal.QueryServices;
using MedicDefense.API.IAM.Domain.Repositories;
using MedicDefense.API.IAM.Domain.Services;
using MedicDefense.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using MedicDefense.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using MedicDefense.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using MedicDefense.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using MedicDefense.API.IAM.Infrastructure.Tokens.JWT.Services;
using MedicDefense.API.IAM.Interfaces.ACL;
using MedicDefense.API.IAM.Interfaces.ACL.Services;
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

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(options =>
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
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
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer", Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Communication Bounded Context Injection Configuration
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();
builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();
builder.Services.AddScoped<INotificationContextFacade, NotificationContextFacade>();

builder.Services.AddScoped<ILegalCaseRepository, LegalCaseRepository>();
builder.Services.AddScoped<ILegalCaseQueryService, LegalCaseQueryService>();
builder.Services.AddScoped<ILegalCaseCommandService, LegalCaseCommandService>();

builder.Services.AddScoped<IEducationalResourceCommandService, EducationalResourceCommandService>();
builder.Services.AddScoped<IEducationalResourceQueryService, EducationalResourceQueryService>();
builder.Services.AddScoped<IEducationalResourceRepository, EducationalResourceRepository>();

builder.Services.AddScoped<IConsultRepository, ConsultRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>();
builder.Services.AddScoped<IConsultCommandService, ConsultCommandService>();
builder.Services.AddScoped<IConsultQueryService, ConsultQueryService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

// Profile Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

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

// Add authorization middleware to pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();