using Exercicio3.Data;
using Exercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Repositories
{
    public class CajeroRepository : ICajeroRepository
    {
        private readonly APIContext _context;

        public CajeroRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cajero>> GetAllAsync()
        {
            return await _context.Cajeros.ToListAsync(); // Recuperar todos los cajeros de la base de datos
        }

        public async Task<Cajero> GetByIdAsync(int id)
        {
            return await _context.Cajeros.FindAsync(id); // Buscar un cajero por su id en la base de datos
        }

        public async Task<Cajero> CreateAsync(Cajero cajero)
        {
            _context.Cajeros.Add(cajero); // Agregar un nuevo cajero al contexto
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return cajero; // Devolver el cajero creado
        }

        public async Task<Cajero> UpdateAsync(int id, Cajero cajero)
        {
            if (!_context.Cajeros.Any(c => c.Codigo == id))
                return null; // Verificar si el cajero con el id especificado existe

            cajero.Codigo = id; // Actualizar el código del cajero con el id especificado
            _context.Cajeros.Update(cajero); // Actualizar el cajero en el contexto
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return cajero; // Devolver el cajero actualizado
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cajero = await _context.Cajeros.FindAsync(id); // Buscar el cajero por su id en la base de datos
            if (cajero == null)
                return false; // Si no se encuentra el cajero, devolver false

            _context.Cajeros.Remove(cajero); // Eliminar el cajero del contexto
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return true; // Devolver true para indicar que se eliminó el cajero
        }
    }
}
