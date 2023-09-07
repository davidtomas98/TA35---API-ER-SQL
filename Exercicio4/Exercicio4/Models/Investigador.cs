using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Models
{
    public class Investigador
    {
        [Key]
        [StringLength(8)]
        public required string DNI { get; set; } // Número de identificación único del investigador

        [Required]
        [StringLength(150)]
        public required string NomApels { get; set; } // Nombre y apellidos del investigador

        public int FacultadCodigo { get; set; } // Código de la facultad a la que pertenece el investigador
        public required Facultad Facultad { get; set; } // Facultad a la que pertenece el investigador

        public required ICollection<Reserva> Reservas { get; set; } // Colección de reservas realizadas por el investigador
    }
}
