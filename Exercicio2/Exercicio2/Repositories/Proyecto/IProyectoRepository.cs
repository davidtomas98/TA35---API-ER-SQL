using Exercicio2.Models;

namespace Exercicio2.Repositories
{
    public interface IProyectoRepository
    {
        // Obtiene un proyecto por su ID
        Task<Proyecto> GetByIdAsync(string id);

        // Obtiene todas los proyectos
        Task<IEnumerable<Proyecto>> GetAllAsync();

        // Crea un nuevo proyecto
        Task CreateAsync(Proyecto proyecto);

        // Actualiza un proyecto existente
        Task UpdateAsync(Proyecto proyecto);

        // Elimina un proyecto por su ID
        Task DeleteAsync(string id);
    }
}
