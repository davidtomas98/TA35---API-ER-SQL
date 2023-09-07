using Exercicio4.Models;
using Exercicio4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Controllers
{
    // Define la ruta base para todas las rutas de este controlador
    [Route("api/investigadores")]
    [ApiController]
    public class InvestigadorC : ControllerBase
    {
        private readonly IInvestigadorRepository _repository;

        // Inyecta la dependencia del repositorio en el constructor
        public InvestigadorC(IInvestigadorRepository repository)
        {
            _repository = repository;
        }

        // Endpoint para obtener todos los investigadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investigador>>> GetInvestigadores()
        {
            var investigadores = await _repository.GetAllAsync();
            return Ok(investigadores); // Devuelve una respuesta HTTP 200 OK con los investigadores
        }

        // Endpoint para obtener un investigador por su DNI
        [HttpGet("{dni}")]
        public async Task<ActionResult<Investigador>> GetInvestigador(string dni)
        {
            var investigador = await _repository.GetByDNIAsync(dni);

            if (investigador == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el investigador no existe
            }

            return Ok(investigador); // Devuelve una respuesta HTTP 200 OK con el investigador encontrado
        }

        // Endpoint para crear un nuevo investigador
        [HttpPost]
        public async Task<ActionResult<Investigador>> PostInvestigador(Investigador investigador)
        {
            var createdInvestigador = await _repository.CreateAsync(investigador);
            return CreatedAtAction(nameof(GetInvestigador), new { dni = createdInvestigador.DNI }, createdInvestigador);
            // Devuelve una respuesta HTTP 201 Created con el investigador creado y una URL para obtenerlo
        }

        // Endpoint para actualizar un investigador existente
        [HttpPut("{dni}")]
        public async Task<IActionResult> PutInvestigador(string dni, Investigador investigador)
        {
            if (dni != investigador.DNI)
            {
                return BadRequest(); // Devuelve una respuesta HTTP 400 Bad Request si el DNI no coincide
            }

            var updatedInvestigador = await _repository.UpdateAsync(dni, investigador);

            if (updatedInvestigador == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el investigador no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la actualización fue exitosa
        }

        // Endpoint para eliminar un investigador por su DNI
        [HttpDelete("{dni}")]
        public async Task<IActionResult> DeleteInvestigador(string dni)
        {
            var deleted = await _repository.DeleteAsync(dni);

            if (!deleted)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si el investigador no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la eliminación fue exitosa
        }
    }
}
