using Exercicio1.Data; // Importa el contexto de datos
using Exercicio1.Models; // Importa los modelos
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly APIContext _context;

        public ProveedorRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todos los proveedores
        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        // Obtiene un proveedor por su ID
        public async Task<Proveedor> GetByIdAsync(string id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        // Crea un nuevo proveedor
        public async Task<Proveedor> CreateAsync(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        // Actualiza un proveedor existente por su ID
        public async Task<Proveedor> UpdateAsync(string id, Proveedor proveedor)
        {
            var existingProveedor = await _context.Proveedores.FindAsync(id);

            if (existingProveedor == null)
                return null;

            existingProveedor.Nombre = proveedor.Nombre;

            await _context.SaveChangesAsync();

            return existingProveedor;
        }

        // Elimina un proveedor por su ID
        public async Task<bool> DeleteAsync(string id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
                return false;

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
