using Exercicio4.Data;
using Exercicio4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Repositories
{
    public class InvestigadorRepository : IInvestigadorRepository
    {
        private readonly APIContext _context;

        public InvestigadorRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todos los investigadores de la base de datos
        public async Task<IEnumerable<Investigador>> GetAllAsync()
        {
            return await _context.Investigadores.ToListAsync();
        }

        // Obtiene un investigador por su número de DNI
        public async Task<Investigador> GetByDNIAsync(string dni)
        {
            return await _context.Investigadores.FindAsync(dni);
        }

        // Crea un nuevo investigador en la base de datos
        public async Task<Investigador> CreateAsync(Investigador investigador)
        {
            _context.Investigadores.Add(investigador);
            await _context.SaveChangesAsync();
            return investigador;
        }

        // Actualiza un investigador existente en la base de datos por su número de DNI
        public async Task<Investigador> UpdateAsync(string dni, Investigador investigador)
        {
            if (!_context.Investigadores.Any(i => i.DNI == dni))
            {
                return null; // No se encontró el investigador a actualizar
            }

            _context.Entry(investigador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return investigador;
        }

        // Elimina un investigador de la base de datos por su número de DNI
        public async Task<bool> DeleteAsync(string dni)
        {
            var investigador = await _context.Investigadores.FindAsync(dni);
            if (investigador == null)
            {
                return false; // No se encontró el investigador a eliminar
            }

            _context.Investigadores.Remove(investigador);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
