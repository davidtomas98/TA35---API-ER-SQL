using Exercicio4.Models;

namespace Exercicio4.Repositories
{
    public interface IReservaRepository
    {
        // Obtiene todas las reservas de la base de datos
        Task<IEnumerable<Reserva>> GetAllAsync();

        // Obtiene una reserva por el número de DNI del investigador y el número de serie del equipo
        Task<Reserva> GetByDNIAndNumSerieAsync(string dni, string numSerie);

        // Crea una nueva reserva en la base de datos
        Task<Reserva> CreateAsync(Reserva reserva);

        // Actualiza una reserva existente en la base de datos por el número de DNI del investigador y el número de serie del equipo
        Task<Reserva> UpdateAsync(string dni, string numSerie, Reserva reserva);

        // Elimina una reserva de la base de datos por el número de DNI del investigador y el número de serie del equipo
        Task<bool> DeleteAsync(string dni, string numSerie);
    }
}
