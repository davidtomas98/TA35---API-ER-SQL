using Exercicio2.Models;

namespace Exercicio2.Repositories
{
    public interface ICientificoRepository
    {
        // Obtiene un científico por su DNI
        Task<Cientifico> GetByDniAsync(string dni);

        // Obtiene todas los científicos
        Task<IEnumerable<Cientifico>> GetAllAsync();

        // Crea un nuevo científico
        Task CreateAsync(Cientifico cientifico);

        // Actualiza un científico existente
        Task UpdateAsync(Cientifico cientifico);

        // Elimina un científico por su DNI
        Task DeleteAsync(string dni);
    }
}
