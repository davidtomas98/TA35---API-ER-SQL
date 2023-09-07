using Exercicio3.Data;
using Exercicio3.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.

builder.Services.AddControllers();
// Aprende más sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la base de datos
builder.Services.AddDbContext<APIContext>();

// Configurar la inyección de dependencias para los repositorios
builder.Services.AddScoped<ICajeroRepository, CajeroRepository>();
builder.Services.AddScoped<IMaquinaRegistradoraRepository, MaquinaRegistradoraRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

var app = builder.Build();

// Configurar el flujo de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilitar Swagger en el entorno de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireccionar solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Habilitar la autorización
app.UseAuthorization();

// Mapear las rutas de controladores
app.MapControllers();

// Iniciar la aplicación
app.Run();
