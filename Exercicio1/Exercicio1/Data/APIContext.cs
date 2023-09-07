using Exercicio1.Models; // Importa los modelos
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Importa la configuración
using System;

namespace Exercicio1.Data
{
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Define los DbSet para las entidades
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Suministra> Suministra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la clave primaria compuesta para la entidad Suministra
            modelBuilder.Entity<Suministra>()
                .HasKey(s => new { s.CodigoPieza, s.IdProveedor });

            // Configura la relación uno a uno entre Suministra y Pieza con eliminación en cascada
            modelBuilder.Entity<Suministra>()
                .HasOne(s => s.Pieza)
                .WithOne(p => p.Suministra)
                .HasForeignKey<Suministra>(s => s.CodigoPieza)
                .OnDelete(DeleteBehavior.Cascade);

            // Configura la relación uno a uno entre Suministra y Proveedor con eliminación en cascada
            modelBuilder.Entity<Suministra>()
                .HasOne(s => s.Proveedor)
                .WithOne(p => p.Suministra)
                .HasForeignKey<Suministra>(s => s.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obtiene la cadena de conexión desde la configuración
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            // Configura la conexión a la base de datos MySQL
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
