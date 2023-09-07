using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Models
{
    public class Equipo
    {
        [Key]
        [StringLength(4)]
        public required string NumSerie { get; set; } // Número de serie del equipo

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre del equipo

        public int FacultadCodigo { get; set; } // Código de la facultad a la que pertenece el equipo
        public required Facultad Facultad { get; set; } // Referencia a la facultad a la que pertenece el equipo

        public required ICollection<Reserva> Reservas { get; set; } // Colección de reservas relacionadas con el equipo
    }
}
