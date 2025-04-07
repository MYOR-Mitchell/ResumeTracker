using Microsoft.EntityFrameworkCore;
using ResumeTracker.Core.Interfaces;
using ResumeTracker.Data;
using ResumeTracker.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ResumeTrackerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITrackedApplicationRepository, TrackedApplicationRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
