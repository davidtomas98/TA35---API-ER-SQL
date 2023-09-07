using System.ComponentModel.DataAnnotations;

namespace Exercicio2.Models
{
    public class Proyecto
    {
        [Key]
        [StringLength(4)]
        public string Id { get; set; } // ID del proyecto (clave primaria)

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // Nombre del proyecto

        public int Horas { get; set; } // Número de horas del proyecto

        public ICollection<Asignado_A> Asignados { get; set; } // Colección de asignaciones asociadas a este proyecto
    }
}
