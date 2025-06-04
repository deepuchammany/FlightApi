using FlightApi.Data;
using FlightApi.Repositories;
using FlightApi.Seed;
using FlightApi.Services;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Entry point for the Flight API application.
/// Configures services, middleware, and seeds initial data.
/// </summary>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FlightContext>(opt => opt.UseInMemoryDatabase("FlightsDb"));
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FlightContext>();
    FlightSeeder.SeedFlights(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
