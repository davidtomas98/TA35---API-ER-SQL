using Exercicio3.Data;
using Exercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly APIContext _context;

        public ProductoRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todos los productos de la base de datos de manera asíncrona.
        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        // Obtiene un producto por su id de manera asíncrona.
        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        // Crea un nuevo producto en la base de datos de manera asíncrona.
        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        // Actualiza un producto existente en la base de datos de manera asíncrona.
        public async Task<Producto> UpdateAsync(int id, Producto producto)
        {
            // Verifica si el producto con el id proporcionado existe en la base de datos.
            if (!_context.Productos.Any(p => p.Codigo == id))
                return null;

            producto.Codigo = id; // Actualiza el código del producto.
            _context.Productos.Update(producto); // Actualiza los datos del producto.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
            return producto;
        }

        // Elimina un producto por su id de manera asíncrona.
        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id); // Busca el producto por su id.
            if (producto == null)
                return false; // Si el producto no existe, retorna falso.

            _context.Productos.Remove(producto); // Elimina el producto de la base de datos.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
            return true;
        }
    }
}
