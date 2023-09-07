using Exercicio4.Models;

namespace Exercicio4.Repositories
{
    public interface IInvestigadorRepository
    {
        // Obtiene todos los investigadores disponibles
        Task<IEnumerable<Investigador>> GetAllAsync();

        // Obtiene un investigador por su DNI
        Task<Investigador> GetByDNIAsync(string dni);

        // Crea un nuevo investigador
        Task<Investigador> CreateAsync(Investigador investigador);

        // Actualiza la información de un investigador
        Task<Investigador> UpdateAsync(string dni, Investigador investigador);

        // Elimina un investigador por su DNI
        Task<bool> DeleteAsync(string dni);
    }
}
