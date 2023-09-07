using Exercicio1.Data;
using Exercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Repositories
{
    public class SuministraRepository : ISuministraRepository
    {
        private readonly APIContext _context;

        public SuministraRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todos los suministros
        public async Task<IEnumerable<Suministra>> GetAllAsync()
        {
            return await _context.Suministra.ToListAsync();
        }

        // Obtiene un suministro por el código de pieza y el ID del proveedor
        public async Task<Suministra> GetByCodigoPiezaIdProveedorAsync(int codigoPieza, string idProveedor)
        {
            return await _context.Suministra.FindAsync(codigoPieza, idProveedor);
        }

        // Crea un nuevo suministro
        public async Task<Suministra> CreateAsync(Suministra suministra)
        {
            _context.Suministra.Add(suministra);
            await _context.SaveChangesAsync();
            return suministra;
        }

        // Actualiza un suministro existente por el código de pieza y el ID del proveedor
        public async Task<Suministra> UpdateAsync(int codigoPieza, string idProveedor, Suministra suministra)
        {
            var existingSuministra = await _context.Suministra.FindAsync(codigoPieza, idProveedor);

            if (existingSuministra == null)
                return null;

            existingSuministra.Precio = suministra.Precio;

            await _context.SaveChangesAsync();

            return existingSuministra;
        }

        // Elimina un suministro por el código de pieza y el ID del proveedor
        public async Task<bool> DeleteAsync(int codigoPieza, string idProveedor)
        {
            var suministra = await _context.Suministra.FindAsync(codigoPieza, idProveedor);

            if (suministra == null)
                return false;

            _context.Suministra.Remove(suministra);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
