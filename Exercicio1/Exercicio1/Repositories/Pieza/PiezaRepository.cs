using Exercicio1.Data; // Importa el contexto de la base de datos
using Exercicio1.Models; // Importa los modelos
using Microsoft.EntityFrameworkCore;

namespace Exercicio1.Repositories
{
    public class PiezaRepository : IPiezaRepository
    {
        private readonly APIContext _context;

        public PiezaRepository(APIContext context)
        {
            _context = context; // Inyecta el contexto de la base de datos
        }

        public async Task<IEnumerable<Pieza>> GetAllAsync()
        {
            return await _context.Piezas.ToListAsync(); // Obtiene todas las piezas desde la base de datos
        }

        public async Task<Pieza> GetByIdAsync(int id)
        {
            return await _context.Piezas.FindAsync(id); // Busca una pieza por su ID en la base de datos
        }

        public async Task<Pieza> CreateAsync(Pieza pieza)
        {
            _context.Piezas.Add(pieza); // Agrega una nueva pieza al contexto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            return pieza; // Devuelve la pieza creada
        }

        public async Task<Pieza> UpdateAsync(int id, Pieza pieza)
        {
            var existingPieza = await _context.Piezas.FindAsync(id); // Busca la pieza existente por su ID

            if (existingPieza == null)
                return null; // Si no se encuentra, retorna null

            existingPieza.Nombre = pieza.Nombre; // Actualiza el nombre de la pieza existente

            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return existingPieza; // Devuelve la pieza actualizada
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pieza = await _context.Piezas.FindAsync(id); // Busca la pieza por su ID

            if (pieza == null)
                return false; // Si no se encuentra, retorna falso

            _context.Piezas.Remove(pieza); // Elimina la pieza del contexto
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return true; // Retorna verdadero indicando que la eliminación fue exitosa
        }
    }
}
