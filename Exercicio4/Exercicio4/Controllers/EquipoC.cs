using System;
using Exercicio4.Models;
using Exercicio4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Controllers
{
    // Define la ruta base para todas las rutas de este controlador
    [Route("api/equipos")]
    [ApiController]
    public class EquipoC : ControllerBase
    {
        private readonly IEquipoRepository _repository;

        // Inyecta la dependencia del repositorio en el constructor
        public EquipoC(IEquipoRepository repository)
        {
            _repository = repository;
        }

        // Endpoint para obtener todos los equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos()
        {
            var equipos = await _repository.GetAllAsync();
            return Ok(equipos); // Devuelve una respuesta HTTP 200 OK con los equipos
        }

        // Endpoint para obtener un equipo por su número de serie
        [HttpGet("{numSerie}")]
        public async Task<ActionResult<Equipo>> GetEquipo(string numSerie)
        {
            var equipo = await _repository.GetByNumSerieAsync(numSerie);

            if (equipo == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el equipo no existe
            }

            return Ok(equipo); // Devuelve una respuesta HTTP 200 OK con el equipo encontrado
        }

        // Endpoint para crear un nuevo equipo
        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo(Equipo equipo)
        {
            var createdEquipo = await _repository.CreateAsync(equipo);
            return CreatedAtAction(nameof(GetEquipo), new { numSerie = createdEquipo.NumSerie }, createdEquipo);
            // Devuelve una respuesta HTTP 201 Created con el equipo creado y una URL para obtenerlo
        }

        // Endpoint para actualizar un equipo existente
        [HttpPut("{numSerie}")]
        public async Task<IActionResult> PutEquipo(string numSerie, Equipo equipo)
        {
            if (numSerie != equipo.NumSerie)
            {
                return BadRequest(); // Devuelve una respuesta HTTP 400 Bad Request si el número de serie no coincide
            }

            var updatedEquipo = await _repository.UpdateAsync(numSerie, equipo);

            if (updatedEquipo == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el equipo no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la actualización fue exitosa
        }

        // Endpoint para eliminar un equipo por su número de serie
        [HttpDelete("{numSerie}")]
        public async Task<IActionResult> DeleteEquipo(string numSerie)
        {
            var deleted = await _repository.DeleteAsync(numSerie);

            if (!deleted)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el equipo no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la eliminación fue exitosa
        }
    }
}
