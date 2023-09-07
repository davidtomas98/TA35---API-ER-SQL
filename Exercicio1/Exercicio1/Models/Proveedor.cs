using System.ComponentModel.DataAnnotations;

namespace Exercicio1.Models
{
    public class Proveedor
    {
        [Key]
        [StringLength(4)]
        public required string Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }

        public Suministra? Suministra { get; set; }
    }
}

