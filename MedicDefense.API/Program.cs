using MedicDefense.API.Consultation.Application.Interfaces;
using MedicDefense.API.Consultation.Application.Services;
using MedicDefense.API.Consultation.Infrastructure.Repositories;
using MedicDefense.API.Consultation.Interfaces;
using MedicDefense.API.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IConsultRepository, ConsultRepository>(); 
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(); 
builder.Services.AddScoped<ILawyerRepository, LawyerRepository>(); 
builder.Services.AddScoped<IConsultationService, ConsultationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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