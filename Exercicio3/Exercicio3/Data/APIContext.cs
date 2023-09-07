using Exercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Data
{
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Definir DbSet para cada entidad
        public DbSet<Cajero> Cajeros { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<MaquinaRegistradora> MaquinasRegistradoras { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        // Configuración de relaciones y restricciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar clave primaria compuesta para Venta
            modelBuilder.Entity<Venta>()
                .HasKey(v => new { v.CajeroCodigo, v.ProductoCodigo, v.MaquinaCodigo });

            // Configurar relación entre Venta y Cajero
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cajero)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.CajeroCodigo)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relación entre Venta y Producto
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Producto)
                .WithMany(p => p.Ventas)
                .HasForeignKey(v => v.ProductoCodigo)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relación entre Venta y MaquinaRegistradora
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Maquina)
                .WithMany(m => m.Ventas)
                .HasForeignKey(v => v.MaquinaCodigo)
                .OnDelete(DeleteBehavior.Cascade);
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
