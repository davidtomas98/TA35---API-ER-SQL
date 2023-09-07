using Microsoft.AspNetCore.Mvc;
using Exercicio2.Repositories;
using Exercicio2.Models;

namespace Exercicio2.Controllers
{
    [ApiController]
    [Route("api/proyectos")]
    public class ProyectoC : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;

        public ProyectoC(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        // Obtiene una lista de todos los proyectos
        [HttpGet]
        public async Task<IEnumerable<Proyecto>> GetAll()
        {
            return await _proyectoRepository.GetAllAsync();
        }

        // Obtiene un proyecto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetById(string id)
        {
            var proyecto = await _proyectoRepository.GetByIdAsync(id);
            if (proyecto == null)
            {
                return NotFound(); // Si el proyecto no se encuentra, devuelve un error NotFound
            }
            return proyecto;
        }

        // Crea un nuevo proyecto y devuelve el resultado de la creación
        [HttpPost]
        public async Task<ActionResult<Proyecto>> Create(Proyecto proyecto)
        {
            await _proyectoRepository.CreateAsync(proyecto);

            // Devuelve una respuesta con el estado 201 Created y la ubicación del nuevo proyecto
            return CreatedAtAction(nameof(GetById), new { id = proyecto.Id }, proyecto);
        }

        // Actualiza un proyecto existente por su ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return BadRequest(); // Si el ID en la URL no coincide con el ID en el objeto, devuelve un error BadRequest
            }

            await _proyectoRepository.UpdateAsync(proyecto);
            return NoContent(); // Devuelve un resultado sin contenido si la actualización es exitosa
        }

        // Elimina un proyecto por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var proyecto = await _proyectoRepository.GetByIdAsync(id);
            if (proyecto == null)
            {
                return NotFound(); // Si el proyecto no se encuentra, devuelve un error NotFound
            }

            await _proyectoRepository.DeleteAsync(id);
            return NoContent(); // Devuelve un resultado sin contenido si la eliminación es exitosa
        }
    }
}
