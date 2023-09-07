using Exercicio3.Data;
using Exercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly APIContext _context;

        // Constructor que recibe el contexto de la base de datos
        public VentaRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todas las ventas de la base de datos
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _context.Ventas.ToListAsync();
        }

        // Obtiene una venta por los códigos de cajero, producto y máquina
        public async Task<Venta> GetByIdAsync(int cajeroCodigo, int productoCodigo, int maquinaCodigo)
        {
            return await _context.Ventas
                .FirstOrDefaultAsync(v => v.CajeroCodigo == cajeroCodigo && v.ProductoCodigo == productoCodigo && v.MaquinaCodigo == maquinaCodigo);
        }

        // Crea una nueva venta en la base de datos
        public async Task<Venta> CreateAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        // Actualiza una venta existente en la base de datos
        public async Task<Venta> UpdateAsync(Venta venta)
        {
            _context.Entry(venta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(venta.CajeroCodigo, venta.ProductoCodigo, venta.MaquinaCodigo))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return venta;
        }

        // Elimina una venta de la base de datos por los códigos de cajero, producto y máquina
        public async Task<bool> DeleteAsync(int cajeroCodigo, int productoCodigo, int maquinaCodigo)
        {
            var venta = await GetByIdAsync(cajeroCodigo, productoCodigo, maquinaCodigo);
            if (venta == null)
            {
                return false;
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return true;
        }

        // Busca ventas en la base de datos por códigos de cajero, producto y/o máquina
        public async Task<IEnumerable<Venta>> SearchAsync(int? cajeroCodigo, int? productoCodigo, int? maquinaCodigo)
        {
            var query = _context.Ventas.AsQueryable();

            if (cajeroCodigo.HasValue)
            {
                query = query.Where(v => v.CajeroCodigo == cajeroCodigo.Value);
            }

            if (productoCodigo.HasValue)
            {
                query = query.Where(v => v.ProductoCodigo == productoCodigo.Value);
            }

            if (maquinaCodigo.HasValue)
            {
                query = query.Where(v => v.MaquinaCodigo == maquinaCodigo.Value);
            }

            return await query.ToListAsync();
        }

        // Verifica si una venta existe en la base de datos por los códigos de cajero, producto y máquina
        private bool VentaExists(int cajeroCodigo, int productoCodigo, int maquinaCodigo)
        {
            return _context.Ventas.Any(v => v.CajeroCodigo == cajeroCodigo && v.ProductoCodigo == productoCodigo && v.MaquinaCodigo == maquinaCodigo);
        }
    }
}
