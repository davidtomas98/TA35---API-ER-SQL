using Exercicio4.Models;

namespace Exercicio4.Repositories
{
    public interface IFacultadRepository
    {
        // Obtiene todas las facultades disponibles
        Task<IEnumerable<Facultad>> GetAllAsync();

        // Obtiene una facultad por su código
        Task<Facultad> GetByCodeAsync(int codigo);

        // Crea una nueva facultad
        Task<Facultad> CreateAsync(Facultad facultad);

        // Actualiza la información de una facultad
        Task<Facultad> UpdateAsync(int codigo, Facultad facultad);

        // Elimina una facultad por su código
        Task<bool> DeleteAsync(int codigo);
    }
}
