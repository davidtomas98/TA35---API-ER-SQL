using System.ComponentModel.DataAnnotations;

namespace Exercicio2.Models
{
    public class Asignado_A
    {
        [Key]
        public int Id { get; set; } // Identificador único de la asignación

        [Required]
        [StringLength(8)]
        public string CientificoDni { get; set; } // DNI del científico asignado

        [Required]
        [StringLength(4)]
        public string ProyectoId { get; set; } // ID del proyecto asignado

        public Cientifico Cientifico { get; set; } // Propiedad de navegación a la entidad Cientifico
        public Proyecto Proyecto { get; set; } // Propiedad de navegación a la entidad Proyecto
    }
}
