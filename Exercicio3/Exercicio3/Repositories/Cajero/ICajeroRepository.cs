using Exercicio3.Models;

namespace Exercicio3.Repositories
{
    public interface ICajeroRepository
    {
        Task<IEnumerable<Cajero>> GetAllAsync(); // Obtener todos los cajeros de la base de datos
        Task<Cajero> GetByIdAsync(int id); // Obtener un cajero por su id
        Task<Cajero> CreateAsync(Cajero cajero); // Crear un nuevo cajero
        Task<Cajero> UpdateAsync(int id, Cajero cajero); // Actualizar un cajero existente
        Task<bool> DeleteAsync(int id); // Eliminar un cajero por su id
    }
}
