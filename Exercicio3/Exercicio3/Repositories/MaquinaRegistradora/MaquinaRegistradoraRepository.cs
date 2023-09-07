using Exercicio3.Data;
using Exercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio3.Repositories
{
    public class MaquinaRegistradoraRepository : IMaquinaRegistradoraRepository
    {
        private readonly APIContext _context;

        public MaquinaRegistradoraRepository(APIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaquinaRegistradora>> GetAllAsync()
        {
            return await _context.MaquinasRegistradoras.ToListAsync(); // Obtener todas las máquinas registradoras de la base de datos
        }

        public async Task<MaquinaRegistradora> GetByIdAsync(int id)
        {
            return await _context.MaquinasRegistradoras.FindAsync(id); // Obtener una máquina registradora por su id
        }

        public async Task<MaquinaRegistradora> CreateAsync(MaquinaRegistradora maquinaRegistradora)
        {
            _context.MaquinasRegistradoras.Add(maquinaRegistradora); // Agregar una nueva máquina registradora a la base de datos
            await _context.SaveChangesAsync();
            return maquinaRegistradora;
        }

        public async Task<MaquinaRegistradora> UpdateAsync(int id, MaquinaRegistradora maquinaRegistradora)
        {
            if (!_context.MaquinasRegistradoras.Any(m => m.Codigo == id))
                return null; // Verificar si la máquina registradora existe en la base de datos

            maquinaRegistradora.Codigo = id;
            _context.MaquinasRegistradoras.Update(maquinaRegistradora); // Actualizar una máquina registradora existente
            await _context.SaveChangesAsync();
            return maquinaRegistradora;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var maquinaRegistradora = await _context.MaquinasRegistradoras.FindAsync(id);
            if (maquinaRegistradora == null)
                return false; // Verificar si la máquina registradora existe en la base de datos

            _context.MaquinasRegistradoras.Remove(maquinaRegistradora); // Eliminar una máquina registradora de la base de datos
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
