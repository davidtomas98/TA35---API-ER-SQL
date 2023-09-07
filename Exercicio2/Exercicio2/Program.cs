using System;
using Exercicio2.Data;
using Exercicio2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de inyección de dependencias.
builder.Services.AddControllers();

// Configura Swagger/OpenAPI para la documentación de la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la base de datos.
builder.Services.AddDbContext<APIContext>();

// Registra los repositorios como servicios en el contenedor.
builder.Services.AddScoped<IAsignadoRepository, AsignadoRepository>();
builder.Services.AddScoped<ICientificoRepository, CientificoRepository>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();

var app = builder.Build();

// Configura el pipeline de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger para la documentación de API en entorno de desarrollo.
    app.UseSwaggerUI(); // Configura la interfaz web de Swagger para interactuar con la documentación.
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS.

app.UseAuthorization(); // Agrega autorización a las solicitudes.

app.MapControllers(); // Mapea las rutas de los controladores.

app.Run(); // Ejecuta la aplicación.
