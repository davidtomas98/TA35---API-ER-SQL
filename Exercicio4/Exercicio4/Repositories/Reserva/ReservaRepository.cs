using Exercicio4.Data;
using Exercicio4.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio4.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly APIContext _context;

        public ReservaRepository(APIContext context)
        {
            _context = context;
        }

        // Obtiene todas las reservas de la base de datos
        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        // Obtiene una reserva por el número de DNI del investigador y el número de serie del equipo
        public async Task<Reserva> GetByDNIAndNumSerieAsync(string dni, string numSerie)
        {
            return await _context.Reservas
                .Where(r => r.DNI == dni && r.NumSerie == numSerie)
                .FirstOrDefaultAsync();
        }

        // Crea una nueva reserva en la base de datos
        public async Task<Reserva> CreateAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        // Actualiza una reserva existente en la base de datos por el número de DNI del investigador y el número de serie del equipo
        public async Task<Reserva> UpdateAsync(string dni, string numSerie, Reserva reserva)
        {
            var existingReserva = await GetByDNIAndNumSerieAsync(dni, numSerie);

            if (existingReserva == null)
            {
                return null;
            }

            _context.Entry(existingReserva).State = EntityState.Detached;
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        // Elimina una reserva de la base de datos por el número de DNI del investigador y el número de serie del equipo
        public async Task<bool> DeleteAsync(string dni, string numSerie)
        {
            var existingReserva = await GetByDNIAndNumSerieAsync(dni, numSerie);

            if (existingReserva == null)
            {
                return false;
            }

            _context.Reservas.Remove(existingReserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
