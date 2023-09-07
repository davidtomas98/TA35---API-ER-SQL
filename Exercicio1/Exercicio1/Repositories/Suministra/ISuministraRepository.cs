using Exercicio1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercicio1.Repositories
{
    public interface ISuministraRepository
    {
        // Obtiene todos los suministros
        Task<IEnumerable<Suministra>> GetAllAsync();

        // Obtiene un suministro por el código de pieza y el ID del proveedor
        Task<Suministra> GetByCodigoPiezaIdProveedorAsync(int codigoPieza, string idProveedor);

        // Crea un nuevo suministro
        Task<Suministra> CreateAsync(Suministra suministra);

        // Actualiza un suministro existente por el código de pieza y el ID del proveedor
        Task<Suministra> UpdateAsync(int codigoPieza, string idProveedor, Suministra suministra);

        // Elimina un suministro por el código de pieza y el ID del proveedor
        Task<bool> DeleteAsync(int codigoPieza, string idProveedor);
    }
}
