using Exercicio2.Data;
using Exercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio2.Repositories
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly APIContext _dbContext;

        public ProyectoRepository(APIContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtiene un proyecto por su ID
        public async Task<Proyecto> GetByIdAsync(string id)
        {
            return await _dbContext.Proyectos.FindAsync(id);
        }

        // Obtiene todas los proyectos
        public async Task<IEnumerable<Proyecto>> GetAllAsync()
        {
            return await _dbContext.Proyectos.ToListAsync();
        }

        // Crea un nuevo proyecto
        public async Task CreateAsync(Proyecto proyecto)
        {
            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();
        }

        // Actualiza un proyecto existente
        public async Task UpdateAsync(Proyecto proyecto)
        {
            _dbContext.Entry(proyecto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Elimina un proyecto por su ID
        public async Task DeleteAsync(string id)
        {
            var proyecto = await _dbContext.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
