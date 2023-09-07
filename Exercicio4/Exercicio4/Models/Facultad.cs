using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Models
{
    public class Facultad
    {
        [Key]
        public int Codigo { get; set; } // Código único de la facultad

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre de la facultad

        public required ICollection<Investigador> Investigadores { get; set; } // Colección de investigadores asociados a la facultad
        public required ICollection<Equipo> Equipos { get; set; } // Colección de equipos asociados a la facultad
    }
}
