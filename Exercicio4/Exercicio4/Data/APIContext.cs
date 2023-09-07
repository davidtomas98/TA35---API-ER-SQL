using Exercicio4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Data
{
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Define DbSet para cada entidad en el modelo de datos
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Investigador> Investigadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        // Configuración de relaciones y restricciones en el modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasKey(r => new { r.DNI, r.NumSerie });

            modelBuilder.Entity<Facultad>()
                .HasMany(f => f.Investigadores)
                .WithOne(i => i.Facultad)
                .HasForeignKey(i => i.FacultadCodigo);

            modelBuilder.Entity<Facultad>()
                .HasMany(f => f.Equipos)
                .WithOne(e => e.Facultad)
                .HasForeignKey(e => e.FacultadCodigo);

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Reservas)
                .WithOne(r => r.Equipo)
                .HasForeignKey(r => r.NumSerie);

            modelBuilder.Entity<Investigador>()
                .HasMany(i => i.Reservas)
                .WithOne(r => r.Investigador)
                .HasForeignKey(r => r.DNI);
        }

        // Configuración de la conexión a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
