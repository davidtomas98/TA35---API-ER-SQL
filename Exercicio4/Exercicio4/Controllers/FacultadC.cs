using Exercicio4.Models;
using Exercicio4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Controllers
{
    // Define la ruta base para todas las rutas de este controlador
    [Route("api/faculdades")]
    [ApiController]
    public class FacultadC : ControllerBase
    {
        private readonly IFacultadRepository _repository;

        // Inyecta la dependencia del repositorio en el constructor
        public FacultadC(IFacultadRepository repository)
        {
            _repository = repository;
        }

        // Endpoint para obtener todas las facultades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultades()
        {
            var facultades = await _repository.GetAllAsync();
            return Ok(facultades); // Devuelve una respuesta HTTP 200 OK con las facultades
        }

        // Endpoint para obtener una facultad por su código
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int codigo)
        {
            var facultad = await _repository.GetByCodeAsync(codigo);

            if (facultad == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la facultad no existe
            }

            return Ok(facultad); // Devuelve una respuesta HTTP 200 OK con la facultad encontrada
        }

        // Endpoint para crear una nueva facultad
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad facultad)
        {
            var createdFacultad = await _repository.CreateAsync(facultad);
            return CreatedAtAction(nameof(GetFacultad), new { codigo = createdFacultad.Codigo }, createdFacultad);
            // Devuelve una respuesta HTTP 201 Created con la facultad creada y una URL para obtenerla
        }

        // Endpoint para actualizar una facultad existente
        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutFacultad(int codigo, Facultad facultad)
        {
            if (codigo != facultad.Codigo)
            {
                return BadRequest(); // Devuelve una respuesta HTTP 400 Bad Request si el código no coincide
            }

            var updatedFacultad = await _repository.UpdateAsync(codigo, facultad);

            if (updatedFacultad == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la facultad no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la actualización fue exitosa
        }

        // Endpoint para eliminar una facultad por su código
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteFacultad(int codigo)
        {
            var deleted = await _repository.DeleteAsync(codigo);

            if (!deleted)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la facultad no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la eliminación fue exitosa
        }
    }
}
