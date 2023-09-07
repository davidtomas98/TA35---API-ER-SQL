using System.ComponentModel.DataAnnotations;

namespace Exercicio3.Models
{
    public class MaquinaRegistradora
    {
        [Key] // Clave primaria
        public int Codigo { get; set; }

        public int Piso { get; set; } // Número de piso de la máquina

        public ICollection<Venta>? Ventas { get; set; } // Relación con la entidad Venta
    }
}
