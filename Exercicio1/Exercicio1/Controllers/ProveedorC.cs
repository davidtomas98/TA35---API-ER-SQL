using Exercicio1.Models; // Importa los modelos
using Exercicio1.Repositories; // Importa el repositorio
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercicio1.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _repository;

        public ProveedorController(IProveedorRepository repository)
        {
            _repository = repository;
        }

        // GET: api/proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            var proveedores = await _repository.GetAllAsync();
            return Ok(proveedores);
        }

        // GET: api/proveedores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(string id)
        {
            var proveedor = await _repository.GetByIdAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // POST: api/proveedores
        [HttpPost]
        public async Task<ActionResult<Proveedor>> CreateProveedor(Proveedor proveedor)
        {
            var createdProveedor = await _repository.CreateAsync(proveedor);
            return CreatedAtAction(nameof(GetProveedor), new { id = createdProveedor.Id }, createdProveedor);
        }

        // PUT: api/proveedores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProveedor(string id, Proveedor proveedor)
        {
            var updatedProveedor = await _repository.UpdateAsync(id, proveedor);

            if (updatedProveedor == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/proveedores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(string id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
