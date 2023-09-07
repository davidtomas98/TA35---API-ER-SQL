using Exercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio2.Data
{
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Definición de conjuntos de entidades (DbSets)
        public DbSet<Cientifico> Cientificos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Asignado_A> Asignados { get; set; }

        // Configuración de las relaciones y claves primarias en el modelo de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la clave primaria para la entidad Asignado_A
            modelBuilder.Entity<Asignado_A>()
                .HasKey(aa => aa.Id);

            // Configuración de la relación entre Asignado_A y Cientifico
            modelBuilder.Entity<Asignado_A>()
                .HasOne(aa => aa.Cientifico)
                .WithMany(c => c.Asignados)
                .HasForeignKey(aa => aa.CientificoDni);

            // Configuración de la relación entre Asignado_A y Proyecto
            modelBuilder.Entity<Asignado_A>()
                .HasOne(aa => aa.Proyecto)
                .WithMany(p => p.Asignados)
                .HasForeignKey(aa => aa.ProyectoId);
        }

        // Configuración de la conexión y versión del servidor MySQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
