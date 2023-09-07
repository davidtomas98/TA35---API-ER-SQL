using System.ComponentModel.DataAnnotations;

namespace Exercicio2.Models
{
    public class Cientifico
    {
        [Key]
        [StringLength(8)]
        public string Dni { get; set; } // DNI del científico (clave primaria)

        [StringLength(150)]
        public string NomApels { get; set; } // Nombre y apellidos del científico

        public ICollection<Asignado_A> Asignados { get; set; } // Colección de asignaciones asociadas a este científico
    }
}
