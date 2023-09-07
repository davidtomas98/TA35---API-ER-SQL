using Exercicio1.Models; // Importa los modelos

namespace Exercicio1.Repositories
{
    public interface IPiezaRepository
    {
        // Obtiene todas las piezas
        Task<IEnumerable<Pieza>> GetAllAsync();

        // Obtiene una pieza por su ID
        Task<Pieza> GetByIdAsync(int id);

        // Crea una nueva pieza
        Task<Pieza> CreateAsync(Pieza pieza);

        // Actualiza una pieza existente por su ID
        Task<Pieza> UpdateAsync(int id, Pieza pieza);

        // Elimina una pieza por su ID
        Task<bool> DeleteAsync(int id);
    }
}
