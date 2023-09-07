using Exercicio2.Models;

namespace Exercicio2.Repositories
{
    public interface IAsignadoRepository
    {
        // Obtiene todas las asignaciones asociadas a un científico por su DNI
        Task<IEnumerable<Asignado_A>> GetByCientificoDniAsync(string dni);

        // Obtiene todas las asignaciones asociadas a un proyecto por su ID
        Task<IEnumerable<Asignado_A>> GetByProyectoIdAsync(string id);

        // Obtiene una asignación por su ID
        Task<Asignado_A> GetByIdAsync(int id);

        // Crea una nueva asignación
        Task CreateAsync(Asignado_A asignado);

        // Actualiza una asignación existente
        Task UpdateAsync(Asignado_A asignado);

        // Elimina una asignación por su ID
        Task DeleteAsync(int id);
    }
}
