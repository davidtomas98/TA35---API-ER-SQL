using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio3.Models
{
    public class Venta
    {
        [Key, Column(Order = 0)] // Clave primaria compuesta con orden 0
        public int CajeroCodigo { get; set; } // Código del cajero

        [Key, Column(Order = 1)] // Clave primaria compuesta con orden 1
        public int ProductoCodigo { get; set; } // Código del producto

        [Key, Column(Order = 2)] // Clave primaria compuesta con orden 2
        public int MaquinaCodigo { get; set; } // Código de la máquina registradora

        [ForeignKey("CajeroCodigo")] // Clave foránea relacionada con el Cajero
        public Cajero Cajero { get; set; } // Referencia a la entidad Cajero

        [ForeignKey("ProductoCodigo")] // Clave foránea relacionada con el Producto
        public Producto Producto { get; set; } // Referencia a la entidad Producto

        [ForeignKey("MaquinaCodigo")] // Clave foránea relacionada con la Máquina Registradora
        public MaquinaRegistradora Maquina { get; set; } // Referencia a la entidad Máquina Registradora
    }
}
