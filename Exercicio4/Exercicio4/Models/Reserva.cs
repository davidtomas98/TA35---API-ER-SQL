using System.ComponentModel.DataAnnotations;

namespace Exercicio4.Models
{
    public class Reserva
    {
        [Key]
        [StringLength(8)]
        public string DNI { get; set; } // Número de identificación del investigador que realizó la reserva

        [Key]
        [StringLength(4)]
        public string NumSerie { get; set; } // Número de serie del equipo reservado

        public DateTime Comienzo { get; set; } // Fecha y hora de inicio de la reserva
        public DateTime Fin { get; set; } // Fecha y hora de finalización de la reserva

        public Investigador Investigador { get; set; } // Investigador que realizó la reserva
        public Equipo Equipo { get; set; } // Equipo que fue reservado
    }
}
