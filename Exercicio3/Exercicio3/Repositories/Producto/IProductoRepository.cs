using Exercicio3.Models;

namespace Exercicio3.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        // Obtener todos los productos de la base de datos

        Task<Producto> GetByIdAsync(int id);
        // Obtener un producto por su id

        Task<Producto> CreateAsync(Producto producto);
        // Agregar un nuevo producto a la base de datos

        Task<Producto> UpdateAsync(int id, Producto producto);
        // Actualizar un producto existente en la base de datos

        Task<bool> DeleteAsync(int id);
        // Eliminar un producto de la base de datos por su id
    }
}
