using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Models
{
    public class Cajero
    {
        [Key] // Clave primaria
        public int Codigo { get; set; }

        [Required] // Atributo que indica que el campo es obligatorio
        [StringLength(150)] // Longitud máxima del campo
        public required string NomApels { get; set; }

        public ICollection<Venta>? Ventas { get; set; } // Relación con la entidad Venta
    }
}
