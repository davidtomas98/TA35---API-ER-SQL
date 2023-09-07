using Exercicio2.Data;
using Exercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio2.Repositories
{
    public class CientificoRepository : ICientificoRepository
    {
        private readonly APIContext _dbContext;

        public CientificoRepository(APIContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtiene un científico por su DNI
        public async Task<Cientifico> GetByDniAsync(string dni)
        {
            return await _dbContext.Cientificos.FindAsync(dni);
        }

        // Obtiene todas los científicos
        public async Task<IEnumerable<Cientifico>> GetAllAsync()
        {
            return await _dbContext.Cientificos.ToListAsync();
        }

        // Crea un nuevo científico
        public async Task CreateAsync(Cientifico cientifico)
        {
            _dbContext.Cientificos.Add(cientifico);
            await _dbContext.SaveChangesAsync();
        }

        // Actualiza un científico existente
        public async Task UpdateAsync(Cientifico cientifico)
        {
            _dbContext.Entry(cientifico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Elimina un científico por su DNI
        public async Task DeleteAsync(string dni)
        {
            var cientifico = await _dbContext.Cientificos.FindAsync(dni);
            if (cientifico != null)
            {
                _dbContext.Cientificos.Remove(cientifico);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
