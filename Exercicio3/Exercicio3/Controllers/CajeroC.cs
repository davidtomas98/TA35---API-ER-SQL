using Exercicio3.Models;
using Exercicio3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio3.Controllers
{
    [ApiController]
    [Route("api/cajeros")]
    public class CajeroC : ControllerBase
    {
        private readonly ICajeroRepository _cajeroRepository;

        public CajeroC(ICajeroRepository cajeroRepository)
        {
            _cajeroRepository = cajeroRepository;
        }

        // Obtener todos los cajeros
        [HttpGet]
        public async Task<IEnumerable<Cajero>> GetAll()
        {
            return await _cajeroRepository.GetAllAsync();
        }

        // Obtener cajero por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cajero>> GetById(int id)
        {
            var cajero = await _cajeroRepository.GetByIdAsync(id);
            if (cajero == null)
                return NotFound();

            return cajero;
        }

        // Crear nuevo cajero
        [HttpPost]
        public async Task<ActionResult<Cajero>> Create(Cajero cajero)
        {
            var createdCajero = await _cajeroRepository.CreateAsync(cajero);
            return CreatedAtAction(nameof(GetById), new { id = createdCajero.Codigo }, createdCajero);
        }

        // Actualizar cajero por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cajero cajero)
        {
            var updatedCajero = await _cajeroRepository.UpdateAsync(id, cajero);
            if (updatedCajero == null)
                return NotFound();

            return NoContent();
        }

        // Eliminar cajero por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cajeroRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
