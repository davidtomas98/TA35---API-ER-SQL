using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Models
{
    public class Producto
    {
        [Key] // Clave primaria
        public int Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre del producto

        public int Precio { get; set; } // Precio del producto

        public ICollection<Venta>? Ventas { get; set; } // Relación con la entidad Venta
    }
}
