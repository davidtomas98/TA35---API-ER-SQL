using Exercicio4.Data;
using Exercicio4.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias.

builder.Services.AddControllers();
// Aprende más sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la base de datos
builder.Services.AddDbContext<APIContext>();

// Registra los repositorios en el contenedor de dependencias
builder.Services.AddScoped<IFacultadRepository, FacultadRepository>();
builder.Services.AddScoped<IInvestigadorRepository, InvestigadorRepository>();
builder.Services.AddScoped<IEquipoRepository, EquipoRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();

var app = builder.Build();

// Configura la pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
