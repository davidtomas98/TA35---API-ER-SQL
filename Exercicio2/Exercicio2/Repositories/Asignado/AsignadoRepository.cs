using Exercicio2.Data;
using Exercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio2.Repositories
{
    public class AsignadoRepository : IAsignadoRepository
    {
        private readonly APIContext _dbContext;

        public AsignadoRepository(APIContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtiene todas las asignaciones asociadas a un científico por su DNI
        public async Task<IEnumerable<Asignado_A>> GetByCientificoDniAsync(string dni)
        {
            return await _dbContext.Asignados
                .Where(a => a.CientificoDni == dni)
                .ToListAsync();
        }

        // Obtiene todas las asignaciones asociadas a un proyecto por su ID
        public async Task<IEnumerable<Asignado_A>> GetByProyectoIdAsync(string id)
        {
            return await _dbContext.Asignados
                .Where(a => a.ProyectoId == id)
                .ToListAsync();
        }

        // Obtiene una asignación por su ID
        public async Task<Asignado_A> GetByIdAsync(int id)
        {
            return await _dbContext.Asignados.FindAsync(id);
        }

        // Crea una nueva asignación en la base de datos
        public async Task CreateAsync(Asignado_A asignado)
        {
            _dbContext.Asignados.Add(asignado);
            await _dbContext.SaveChangesAsync();
        }

        // Actualiza una asignación existente en la base de datos
        public async Task UpdateAsync(Asignado_A asignado)
        {
            _dbContext.Entry(asignado).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Elimina una asignación por su ID de la base de datos
        public async Task DeleteAsync(int id)
        {
            var asignado = await _dbContext.Asignados.FindAsync(id);
            if (asignado != null)
            {
                _dbContext.Asignados.Remove(asignado);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
