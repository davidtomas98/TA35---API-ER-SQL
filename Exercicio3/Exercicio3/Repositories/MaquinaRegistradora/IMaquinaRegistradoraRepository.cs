using Exercicio3.Models;

namespace Exercicio3.Repositories
{
    public interface IMaquinaRegistradoraRepository
    {
        Task<IEnumerable<MaquinaRegistradora>> GetAllAsync(); // Obtener todas las máquinas registradoras de la base de datos
        Task<MaquinaRegistradora> GetByIdAsync(int id); // Obtener una máquina registradora por su id
        Task<MaquinaRegistradora> CreateAsync(MaquinaRegistradora maquinaRegistradora); // Crear una nueva máquina registradora
        Task<MaquinaRegistradora> UpdateAsync(int id, MaquinaRegistradora maquinaRegistradora); // Actualizar una máquina registradora existente
        Task<bool> DeleteAsync(int id); // Eliminar una máquina registradora por su id
    }
}
