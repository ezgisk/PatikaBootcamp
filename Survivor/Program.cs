using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Survivor;  // Burada 'Survivor' projenizin namespace'i olmalý

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL Baðlantýsý
builder.Services.AddDbContext<SurvivorContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // PostgreSQL baðlantýsý

// API Servisleri
builder.Services.AddControllers();

// Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Survivor API", Version = "v1" });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Survivor API v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
