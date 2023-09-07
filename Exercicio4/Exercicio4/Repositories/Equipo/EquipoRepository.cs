using Exercicio4.Data;
using Exercicio4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly APIContext _context;

        public EquipoRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todos los equipos disponibles
        public async Task<IEnumerable<Equipo>> GetAllAsync()
        {
            return await _context.Equipos.ToListAsync();
        }

        // Obtiene un equipo por su número de serie
        public async Task<Equipo> GetByNumSerieAsync(string numSerie)
        {
            return await _context.Equipos.FindAsync(numSerie);
        }

        // Crea un nuevo equipo
        public async Task<Equipo> CreateAsync(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }

        // Actualiza la información de un equipo
        public async Task<Equipo> UpdateAsync(string numSerie, Equipo equipo)
        {
            if (!_context.Equipos.Any(e => e.NumSerie == numSerie))
            {
                return null;
            }

            _context.Entry(equipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return equipo;
        }

        // Elimina un equipo por su número de serie
        public async Task<bool> DeleteAsync(string numSerie)
        {
            var equipo = await _context.Equipos.FindAsync(numSerie);
            if (equipo == null)
            {
                return false;
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
