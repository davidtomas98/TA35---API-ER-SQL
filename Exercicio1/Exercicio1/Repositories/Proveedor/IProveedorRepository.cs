using Exercicio1.Models; // Importa los modelos

namespace Exercicio1.Repositories
{
    public interface IProveedorRepository
    {
        // Obtiene todos los proveedores
        Task<IEnumerable<Proveedor>> GetAllAsync();

        // Obtiene un proveedor por su ID
        Task<Proveedor> GetByIdAsync(string id);

        // Crea un nuevo proveedor
        Task<Proveedor> CreateAsync(Proveedor proveedor);

        // Actualiza un proveedor existente por su ID
        Task<Proveedor> UpdateAsync(string id, Proveedor proveedor);

        // Elimina un proveedor por su ID
        Task<bool> DeleteAsync(string id);
    }
}
