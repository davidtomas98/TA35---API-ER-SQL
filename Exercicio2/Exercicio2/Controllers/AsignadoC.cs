using Microsoft.AspNetCore.Mvc;
using Exercicio2.Repositories;
using Exercicio2.Models;

namespace Exercicio2.Controllers
{
    [ApiController]
    [Route("api/asignados")]
    public class AsignadoC : ControllerBase
    {
        private readonly IAsignadoRepository _asignadoRepository;

        public AsignadoC(IAsignadoRepository asignadoRepository)
        {
            _asignadoRepository = asignadoRepository;
        }

        // Obtiene una lista de asignaciones por el DNI de un científico
        [HttpGet("cientifico/{dni}")]
        public async Task<IEnumerable<Asignado_A>> GetByCientificoDni(string dni)
        {
            return await _asignadoRepository.GetByCientificoDniAsync(dni);
        }

        // Obtiene una lista de asignaciones por el ID de un proyecto
        [HttpGet("proyecto/{id}")]
        public async Task<IEnumerable<Asignado_A>> GetByProyectoId(string id)
        {
            return await _asignadoRepository.GetByProyectoIdAsync(id);
        }

        // Crea una nueva asignación y devuelve el resultado de la creación
        [HttpPost]
        public async Task<ActionResult<Asignado_A>> Create(Asignado_A asignado)
        {
            await _asignadoRepository.CreateAsync(asignado);

            // Devuelve una respuesta con el estado 201 Created y la ubicación de la nueva asignación
            return CreatedAtAction(nameof(GetByCientificoDni), new { dni = asignado.CientificoDni }, asignado);
        }

        // Actualiza una asignación existente por su ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Asignado_A asignado)
        {
            if (id != asignado.Id)
            {
                return BadRequest(); // Si el ID en la URL no coincide con el ID en el objeto, devuelve un error BadRequest
            }

            await _asignadoRepository.UpdateAsync(asignado);
            return NoContent(); // Devuelve un resultado sin contenido si la actualización es exitosa
        }

        // Elimina una asignación por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignado(int id)
        {
            var asignado = await _asignadoRepository.GetByIdAsync(id);
            if (asignado == null)
            {
                return NotFound(); // Si la asignación no se encuentra, devuelve un error NotFound
            }

            await _asignadoRepository.DeleteAsync(id);

            return NoContent(); // Devuelve un resultado sin contenido si la eliminación es exitosa
        }
    }
}
