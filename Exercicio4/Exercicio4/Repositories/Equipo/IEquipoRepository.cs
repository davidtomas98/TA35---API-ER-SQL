using Exercicio4.Models;

namespace Exercicio4.Repositories
{
    public interface IEquipoRepository
    {
        // Obtiene todos los equipos disponibles
        Task<IEnumerable<Equipo>> GetAllAsync();

        // Obtiene un equipo por su número de serie
        Task<Equipo> GetByNumSerieAsync(string numSerie);

        // Crea un nuevo equipo
        Task<Equipo> CreateAsync(Equipo equipo);

        // Actualiza la información de un equipo
        Task<Equipo> UpdateAsync(string numSerie, Equipo equipo);

        // Elimina un equipo por su número de serie
        Task<bool> DeleteAsync(string numSerie);
    }
}
