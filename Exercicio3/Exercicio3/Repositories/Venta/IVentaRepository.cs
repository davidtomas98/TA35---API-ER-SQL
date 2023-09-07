using Exercicio3.Models;

namespace Exercicio3.Repositories
{
    public interface IVentaRepository
    {
        // Obtiene todas las ventas de la base de datos de manera asíncrona.
        Task<IEnumerable<Venta>> GetAllAsync();

        // Obtiene una venta por los códigos de cajero, producto y máquina de manera asíncrona.
        Task<Venta> GetByIdAsync(int cajeroCodigo, int productoCodigo, int maquinaCodigo);

        // Crea una nueva venta en la base de datos de manera asíncrona.
        Task<Venta> CreateAsync(Venta venta);

        // Actualiza una venta existente en la base de datos de manera asíncrona.
        Task<Venta> UpdateAsync(Venta venta);

        // Elimina una venta por los códigos de cajero, producto y máquina de manera asíncrona.
        Task<bool> DeleteAsync(int cajeroCodigo, int productoCodigo, int maquinaCodigo);

        // Busca ventas por los códigos de cajero, producto y máquina de manera asíncrona.
        Task<IEnumerable<Venta>> SearchAsync(int? cajeroCodigo, int? productoCodigo, int? maquinaCodigo);
    }
}
