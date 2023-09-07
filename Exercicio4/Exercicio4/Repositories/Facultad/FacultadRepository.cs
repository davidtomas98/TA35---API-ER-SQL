using Exercicio4.Data;
using Exercicio4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Repositories
{
    public class FacultadRepository : IFacultadRepository
    {
        private readonly APIContext _context;

        public FacultadRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todas las facultades disponibles
        public async Task<IEnumerable<Facultad>> GetAllAsync()
        {
            return await _context.Facultades.ToListAsync();
        }

        // Obtiene una facultad por su código
        public async Task<Facultad> GetByCodeAsync(int codigo)
        {
            return await _context.Facultades.FindAsync(codigo);
        }

        // Crea una nueva facultad
        public async Task<Facultad> CreateAsync(Facultad facultad)
        {
            _context.Facultades.Add(facultad);
            await _context.SaveChangesAsync();
            return facultad;
        }

        // Actualiza la información de una facultad
        public async Task<Facultad> UpdateAsync(int codigo, Facultad facultad)
        {
            if (!_context.Facultades.Any(f => f.Codigo == codigo))
            {
                return null;
            }

            _context.Entry(facultad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return facultad;
        }

        // Elimina una facultad por su código
        public async Task<bool> DeleteAsync(int codigo)
        {
            var facultad = await _context.Facultades.FindAsync(codigo);
            if (facultad == null)
            {
                return false;
            }

            _context.Facultades.Remove(facultad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
